using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class KnightAttackState : State
    {
        public bool followsTarget;
        public KnightCombatStanceState knightCombatStanceState;
        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            if(followsTarget == true)
            {
                enemyManager.FaceTarget();
            }
            enemyAnimationHandler.enemyAnimator.SetBool("isInteracting", true);
            if(enemyAnimationHandler.enemyAnimator.GetBool("attack") == false)
            {
                followsTarget = false;
                return knightCombatStanceState;
            }
            return this;
        }
    }
}
