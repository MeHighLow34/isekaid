using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class PursueTargetState : State
    {
        public KnightCombatStanceState knightCombatStanceState;
        public MageCombatStanceState mageCombatStanceState;
        public ArcherCombatStanceState archerCombatStanceState;
        public CombatStanceState combatStanceState;
        RaycastHit hit;

        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            enemyAnimationHandler.enemyAnimator.SetBool("isInteracting", false);
            enemyManager.navMeshAgent.speed = 5.6f;
            enemyManager.navMeshAgent.SetDestination(enemyManager.currentTarget.transform.position);
            if (enemyManager.DistanceToEnemy() <= enemyManager.combatStanceStateRange && enemyManager.HasLineOfSight(enemyManager.transform))
            {
                if(knightCombatStanceState != null)
                {
                    return knightCombatStanceState;
                }

                if(mageCombatStanceState != null)
                {
                    return mageCombatStanceState;
                }

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
    }
}
