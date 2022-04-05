using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class MageCombatStanceState : State
    {
        //public Transform rayCastPoint;
        RaycastHit hit;
        public PursueTargetState pursueTargetState;
        public MageAttackState mageAttackState;
       
        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            enemyManager.timeBetweenShots -= Time.deltaTime;
            enemyAnimationHandler.enemyAnimator.SetBool("isInteracting", true);
            enemyAnimationHandler.enemyAnimator.SetBool("combatIdle", true);
            enemyManager.FaceTarget();
            if (enemyManager.HitAFriend(enemyManager.rayCastPosition) && enemyManager.Ally == false)
            {
                return this;
            }
            if (enemyManager.HasLineOfSight(enemyManager.rayCastPosition) == false)
            {
                enemyAnimationHandler.enemyAnimator.SetBool("isInteracting", false);
                enemyAnimationHandler.enemyAnimator.SetBool("combatIdle", false);
                return pursueTargetState;
            }
            if (enemyManager.DistanceToEnemy() <= enemyManager.attackRange && enemyManager.timeBetweenShots <= 0)
            {
                enemyAnimationHandler.enemyAnimator.SetBool("attack", true);
                return mageAttackState;
            }
            return this;
        }
    }
}
