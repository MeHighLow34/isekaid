using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class MageAttackState : State
    {
        public PursueTargetState pursueTargetState;
        public MageCombatStanceState mageCombatStanceState;
        RaycastHit hit;
        bool attack;
        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            enemyManager.timeBetweenShots = 5f;
            enemyAnimationHandler.enemyAnimator.updateMode = AnimatorUpdateMode.Normal;
            attack = enemyAnimationHandler.enemyAnimator.GetBool("attack");
            if (attack == false)
            {
                return mageCombatStanceState;
            }

            return this;
        }
        public bool HasLineOfSight(EnemyManager enemyManager)
        {
            if (Physics.Linecast(enemyManager.transform.position, enemyManager.currentTarget.transform.position, out hit))
            {
                if (hit.transform.gameObject.tag == "Player")
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
