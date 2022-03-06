using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class MageCombatStanceState : State
    {
        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            enemyAnimationHandler.enemyAnimator.SetBool("isInteracting", true);
            enemyAnimationHandler.enemyAnimator.SetBool("combatIdle", true);
            return this;
        }
    }
}
