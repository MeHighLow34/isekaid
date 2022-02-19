using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class IdleState : State
    {
        public PursueTargetState pursueTargetState;
        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, enemyManager.detectionLayer);
            for (int i = 0; i < colliders.Length; i++)
            {
                BaseStats characterStats = colliders[i].transform.GetComponent<BaseStats>();
                if(characterStats != null)
                {
                    if (characterStats.gameObject.tag != "Player") continue;  // We only recognize player as  a valid enemy at this point in development...
                    if(characterStats == this.gameObject.transform.GetComponent<BaseStats>()) continue;
                    Vector3 targetDirection = characterStats.transform.position - transform.position;
                    float viewAbleAngle = Vector3.Angle(targetDirection, transform.forward);
                    if(viewAbleAngle > -50 && viewAbleAngle < 50)
                    {
                        enemyManager.currentTarget = characterStats;
                    }
                }
            }

            if (enemyManager.currentTarget != null)   // If we find enemy we go to chase it
            {
                print(enemyManager.currentTarget.transform.gameObject.name);
                return pursueTargetState;

            }
            else
            {

                return this;
            }
        }
    }
}
