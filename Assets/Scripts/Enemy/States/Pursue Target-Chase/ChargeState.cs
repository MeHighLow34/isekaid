using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class ChargeState : State
    {
        public AttackState attackState;
        public RecoveryState recoveryState;
        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            enemyAnimationHandler.enemyAnimator.SetBool("isInteracting", true);
            enemyManager.FaceTarget();
            float distance = Vector3.Distance(enemyManager.transform.position, enemyManager.currentTarget.transform.position);
            if(distance <= enemyManager.attackRange)
            {
                enemyAnimationHandler.PlayTargetAnimation("Twirl", true);
                enemyAnimationHandler.enemyAnimator.SetBool("isCharging", false);
                if (enemyManager.isRecovering)
                {
                    return recoveryState;
                }
            }
            return this;
        }
    }
}