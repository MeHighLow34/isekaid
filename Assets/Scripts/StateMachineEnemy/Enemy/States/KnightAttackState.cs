using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class KnightAttackState : State
    {
        public KnightCombatStanceState knightCombatStanceState;
        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            enemyAnimationHandler.enemyAnimator.SetBool("isInteracting", true);
            if(enemyAnimationHandler.enemyAnimator.GetBool("attack") == false)
            {
                return knightCombatStanceState;
            }
            return this;
        }
    }
}
