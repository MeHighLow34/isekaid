using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public abstract class State : MonoBehaviour
    {
        public abstract State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler);

    }
}
