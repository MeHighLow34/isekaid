using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class KnightCombatStanceState : State
    {
        public Transform rayCastPoint;
        RaycastHit hit;
        public KnightAttackState knightAttackState;
        public PursueTargetState pursueTargetState;
        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            enemyManager.FaceTarget();
            enemyAnimationHandler.enemyAnimator.SetBool("isInteracting", false);
            enemyAnimationHandler.enemyAnimator.SetBool("combatIdle", true);
            enemyManager.navMeshAgent.speed = 2.4f;
            enemyManager.navMeshAgent.SetDestination(enemyManager.currentTarget.transform.position);
            if (enemyManager.DistanceToEnemy() <= enemyManager.attackRange && HasLineOfSight(enemyManager))
            {
                enemyAnimationHandler.enemyAnimator.SetBool("isInteracting",  true);
                enemyAnimationHandler.enemyAnimator.SetBool("attack", true);
                return knightAttackState;
            }
            if(enemyManager.DistanceToEnemy() >= enemyManager.combatStanceStateRange)
            {
                enemyAnimationHandler.enemyAnimator.SetBool("combatIdle", false);
                return pursueTargetState;
            }
            return this;
        }
        public bool HasLineOfSight(EnemyManager enemyManager)
        {
            if (Physics.Linecast(rayCastPoint.position, enemyManager.currentTarget.transform.position, out hit))
            {
                if (hit.transform.gameObject.tag == enemyManager.currentTarget.gameObject.tag)
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