using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class PatrolState : State
    {

        
        public PursueTargetState pursueTargetState;
        [SerializeField] PatrolPath patrolPath;
        public int currentWaypointIndex = 0;
        Vector3 nextPosition;
        public float atWayPointTimer = 0;
        [Header("Parameters")]
        public float minimumViewAbleAngle = -80f;
        public float maximumViewAbleAngle = 80f;
        [Header("DEBUG")]
        public BaseStats ignoreOurselves;
        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            DetermineEnemy(enemyManager);
            CheckForEnemy(enemyManager);
            enemyManager.navMeshAgent.speed = 2.4f;
            if(patrolPath != null)
            {
                if(AtWayPoint(enemyManager))
                {
                    atWayPointTimer = 0;
                    CycleWaypoint();
                }
                nextPosition = GetCurrentWaypoint();
            }
            if (atWayPointTimer > enemyManager.dwellTime)
            {
                enemyManager.navMeshAgent.SetDestination(nextPosition);
            }
            atWayPointTimer += Time.deltaTime;

            if(enemyManager.currentTarget != null)
            {
                return pursueTargetState;
            }
            return this;
        }

        private void DetermineEnemy(EnemyManager enemyManager)
        {
            if(enemyManager.Ally == true)
            {
                enemyManager.enemyOfMine = "Enemy";
            }
            else
            {
                enemyManager.enemyOfMine = "Player";
            }

        }
        private void CheckForEnemy(EnemyManager enemyManager)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, enemyManager.detectionLayer);
            for (int i = 0; i < colliders.Length; i++)
            {
                BaseStats characterStats = colliders[i].transform.GetComponent<BaseStats>();
                if (characterStats != null)
                {
                    if (characterStats.gameObject.tag != enemyManager.enemyOfMine) continue;  // We only recognize player as  a valid enemy at this point in development...
                    if (characterStats == ignoreOurselves) continue; // ignore ourselves
                   
                    Vector3 targetDirection = characterStats.transform.position - transform.position;
                    float viewAbleAngle = Vector3.Angle(targetDirection, transform.forward);
                    if (viewAbleAngle > minimumViewAbleAngle && viewAbleAngle < maximumViewAbleAngle)
                    {
                        enemyManager.currentTarget = characterStats;
                    }
                }
            }
        }

        private bool AtWayPoint(EnemyManager enemyManager)
        {
            float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
            return distanceToWaypoint < enemyManager.waypointTolerance;
        }

        private void CycleWaypoint()
        {
            currentWaypointIndex = patrolPath.GetNextIndex(currentWaypointIndex);
        }
        private Vector3 GetCurrentWaypoint()
        {
            return patrolPath.GetWayPoint(currentWaypointIndex);
        }
    }
}
