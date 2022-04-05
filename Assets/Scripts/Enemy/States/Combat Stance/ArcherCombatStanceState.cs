using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class ArcherCombatStanceState : State
    {
      //  public Transform rayCastPoint;
        RaycastHit hit;
        public PursueTargetState pursueTargetState;
        public ArcherAttackState archerAttackState;
        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            enemyManager.timeBetweenAttacks -= Time.deltaTime;
            enemyAnimationHandler.enemyAnimator.SetBool("isInteracting", true);
            enemyAnimationHandler.enemyAnimator.SetBool("combatIdle", true);
            enemyManager.FaceTarget();
            if(enemyManager.HitAFriend(enemyManager.rayCastPosition) && enemyManager.Ally == false)
            {
                return this;
            }
            if(enemyManager.HasLineOfSight(enemyManager.rayCastPosition) == false)
            {
                enemyAnimationHandler.enemyAnimator.SetBool("isInteracting", false);
                enemyAnimationHandler.enemyAnimator.SetBool("combatIdle", false);
                return pursueTargetState;
            }
            if(enemyManager.DistanceToEnemy() <= enemyManager.attackRange && enemyManager.timeBetweenAttacks <= 0)
            {
                enemyManager.timeBetweenAttacks = enemyManager.timeBetweenAttacksMaximum;
                enemyAnimationHandler.enemyAnimator.SetBool("attack", true);
                return archerAttackState;
            }
            return this; 
        }        
    }
}
