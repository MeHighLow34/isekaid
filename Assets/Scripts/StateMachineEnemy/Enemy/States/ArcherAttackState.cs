using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class ArcherAttackState : State
    {
        RaycastHit hit;
        PursueTargetState pursueTargetState;
        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            if(HasLineOfSight(enemyManager))
            {


                // Attacking Code Here
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