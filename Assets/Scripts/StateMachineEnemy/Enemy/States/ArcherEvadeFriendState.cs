using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class ArcherEvadeFriendState : State
    {
        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            return this;
        }
    }
}
