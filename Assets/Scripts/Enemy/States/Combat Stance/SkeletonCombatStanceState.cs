using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class SkeletonCombatStanceState : State
    {
        public Transform rayCastPoint;
        public PursueTargetState pursueTargetState;
        public SkeletonAttackState skeletonAttackState;
        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            enemyManager.FaceTarget();
            enemyAnimationHandler.enemyAnimator.SetBool("isInteracting", false);
            enemyAnimationHandler.enemyAnimator.SetBool("combatIdle", true);
            enemyManager.navMeshAgent.speed = 2.4f;
            enemyManager.navMeshAgent.SetDestination(enemyManager.currentTarget.transform.position);
            if (enemyManager.DistanceToEnemy() <= enemyManager.attackRange && enemyManager.HasLineOfSight(rayCastPoint))
            {
                enemyAnimationHandler.enemyAnimator.SetBool("isInteracting", true);
                enemyAnimationHandler.enemyAnimator.SetBool("attack", true);
                return skeletonAttackState;
                
            }
            if (enemyManager.DistanceToEnemy() >= enemyManager.combatStanceStateRange)
            {
                enemyAnimationHandler.enemyAnimator.SetBool("combatIdle", false);
                return pursueTargetState;
            }
            return this;
        }
    }
}
