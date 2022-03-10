using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class ArcherCombatStanceState : State
    {
        public Transform rayCastPoint;
        RaycastHit hit;
        public PursueTargetState pursueTargetState;
        public ArcherAttackState archerAttackState;
        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            enemyManager.timeBetweenAttacks -= Time.deltaTime;
            enemyAnimationHandler.enemyAnimator.SetBool("isInteracting", true);
           // enemyAnimationHandler.enemyAnimator.updateMode = AnimatorUpdateMode.Normal;
            enemyAnimationHandler.enemyAnimator.SetBool("combatIdle", true);
            enemyManager.FaceTarget();
            if(HitAFriend(enemyManager))
            {
                print("My Buddy is In Front of me so I'll wait");
                return this;
            }
            if(HasLineOfSight(enemyManager) == false)
            {
                enemyAnimationHandler.enemyAnimator.SetBool("isInteracting", false);
                enemyAnimationHandler.enemyAnimator.SetBool("combatIdle", false);
                return pursueTargetState;
            }
            if(enemyManager.DistanceToEnemy() <= enemyManager.attackRange && enemyManager.timeBetweenAttacks <= 0)
            {
                enemyManager.timeBetweenAttacks = enemyManager.timeBetweenAttacksMaximum;
                enemyAnimationHandler.enemyAnimator.SetBool("attack", true);
                return archerAttackState;
            }
            return this; 
        }
        public bool HitAFriend(EnemyManager enemyManager)
        {
            if(Physics.Linecast(rayCastPoint.position, enemyManager.currentTarget.transform.position, out hit))
            {
                if(hit.transform.gameObject.tag == "Enemy")
                {
                    print("This idiot is in front of me");
                    return true;
                }
            }
            return false;
        }
        public bool HasLineOfSight(EnemyManager enemyManager)
        {
            if (Physics.Linecast(rayCastPoint.position, enemyManager.currentTarget.transform.position, out hit))
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
