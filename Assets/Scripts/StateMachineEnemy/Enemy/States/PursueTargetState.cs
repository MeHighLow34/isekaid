using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class PursueTargetState : State
    {
        public CombatStanceState combatStanceState;
        RaycastHit hit;

        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            enemyManager.navMeshAgent.enabled = true;
            enemyManager.navMeshAgent.speed = 5.6f;
            float distance = Vector3.Distance(enemyManager.transform.position, enemyManager.currentTarget.transform.position);
            enemyManager.navMeshAgent.SetDestination(enemyManager.currentTarget.transform.position);
            if (distance <= enemyManager.combatStanceStateRange && HasLineOfSight(enemyManager))
            {
                return combatStanceState;
            }
            else
            {

                return this;
            }

            
           
        }
        public bool HasLineOfSight(EnemyManager enemyManager)
        {
            if(Physics.Linecast(enemyManager.transform.position, enemyManager.currentTarget.transform.position, out hit))
            {
                if (hit.transform.gameObject.tag == "Player")
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
