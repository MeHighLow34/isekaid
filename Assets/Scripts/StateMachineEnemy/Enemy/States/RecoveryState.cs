using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Isekai
{
    public class RecoveryState : State
    {
        public CombatStanceState combatStanceState;
        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
           
            enemyAnimationHandler.enemyAnimator.applyRootMotion = true;
            enemyManager.FaceTarget();
            enemyManager.recoveryTime -= Time.deltaTime;
            if (enemyManager.recoveryTime <= 0)
            {
                enemyAnimationHandler.enemyAnimator.SetBool("isRecovering", false);
                enemyManager.recoveryTime = enemyManager.maxRecoveryTime;
                enemyAnimationHandler.enemyAnimator.SetBool("isRecovering", false);
                return combatStanceState;
            }


            return this;
        }
    }
}
