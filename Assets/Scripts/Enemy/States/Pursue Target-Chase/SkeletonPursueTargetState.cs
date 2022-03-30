using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class SkeletonPursueTargetState : PursueTargetState
    {
        public SkeletonCombatStanceState skeletonCombatStanceState;
        public Transform rayCastPosition;
        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            enemyAnimationHandler.enemyAnimator.SetBool("isInteracting", false);
            enemyManager.navMeshAgent.speed = 2.7f;
            enemyManager.navMeshAgent.SetDestination(enemyManager.currentTarget.transform.position);
            if (enemyManager.DistanceToEnemy() <= enemyManager.combatStanceStateRange && enemyManager.HasLineOfSight(rayCastPosition))
            {
                return skeletonCombatStanceState;
            }
            return this;
        }
    }
}
