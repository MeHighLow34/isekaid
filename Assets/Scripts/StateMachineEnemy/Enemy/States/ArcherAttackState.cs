using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class ArcherAttackState : State
    {
        RaycastHit hit;
        public ArcherCombatStanceState combatStanceState;
        public PursueTargetState pursueTargetState;
        public bool attack;
        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            enemyManager.timeBetweenAttacks = enemyManager.timeBetweenAttacksMaximum;
            attack = enemyAnimationHandler.enemyAnimator.GetBool("attack");
            if(attack == false)
            {
                return combatStanceState;
            }
            if(HasLineOfSight(enemyManager))
            {
                enemyAnimationHandler.enemyAnimator.SetBool("attack", true);  
                return this;
            }
            else
            {
                return pursueTargetState;
            }
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