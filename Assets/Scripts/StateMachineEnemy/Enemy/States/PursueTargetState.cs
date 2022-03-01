using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class PursueTargetState : State
    {
        public ArcherCombatStanceState archerCombatStanceState;
        public CombatStanceState combatStanceState;
        RaycastHit hit;

        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            enemyAnimationHandler.enemyAnimator.SetBool("isInteracting", false);
            enemyManager.navMeshAgent.speed = 5.6f;
            enemyManager.navMeshAgent.SetDestination(enemyManager.currentTarget.transform.position);
            if (enemyManager.DistanceToEnemy() <= enemyManager.combatStanceStateRange && HasLineOfSight(enemyManager))
            {
                if(archerCombatStanceState != null)
                {
                    return archerCombatStanceState;
                }
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
