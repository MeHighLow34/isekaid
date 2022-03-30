using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class SkeletonAttackState : State
    {
        public SkeletonCombatStanceState skeletonCombatStanceState;
        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            if (enemyAnimationHandler.enemyAnimator.GetBool("attack") == false)
            {
                return skeletonCombatStanceState;
            }
            return this;
        }
    }
}
