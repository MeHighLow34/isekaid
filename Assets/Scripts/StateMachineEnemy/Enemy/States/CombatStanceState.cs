using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class CombatStanceState : State
    {
        public ChargeState chargeState;
        public AttackState attackState;
        public PursueTargetState pursueTargetState;
        public float cTimer;
          public override State Tick(EnemyManager enemyManager,BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
             {
                enemyManager.FaceTarget();
                #region AnimatorBools
                enemyAnimationHandler.enemyAnimator.SetBool("isInteracting", false);
                enemyAnimationHandler.enemyAnimator.SetBool("combatIdle", true);

                #endregion
                #region NavMesh
            enemyManager.navMeshAgent.speed = 2.4f;
                enemyManager.navMeshAgent.SetDestination(enemyManager.currentTarget.transform.position);
            #endregion

                #region ChargeState 
                cTimer += Time.deltaTime;
                if (cTimer > enemyManager.chargeTimer)
                {
                  cTimer = 0;
                  enemyAnimationHandler.enemyAnimator.SetBool("isCharging", true);
                  return chargeState;
                }
            #endregion
                #region AttackState
             if (enemyManager.DistanceToEnemy() <= enemyManager.attackRange)
                {
                   cTimer = 0;
                   enemyAnimationHandler.enemyAnimator.SetBool("attack", true);
                   return attackState;
                }
            #endregion
                #region PursueTargetState
             if (enemyManager.DistanceToEnemy() >= enemyManager.combatStanceStateRange)
                {
                   cTimer = 0;
                   enemyAnimationHandler.enemyAnimator.SetBool("combatIdle", false);
                   enemyAnimationHandler.enemyAnimator.SetBool("isCharging", false);
                   return pursueTargetState;
                }
            #endregion
            return this;


            // Conditions for ROOT MOTION ANIMATION ARE applyROOTMOTION, navmeshagent DISABLED,  ANIMATOR HAS TO HAVE ANIMATE PHYSICS and in no way shape or form should it have isKinematic ENABLED..........Ok Imma work on that.......LET'S FUCKING GOOOOOO
             }
    }
}

// OLD CODE
//enemyAnimationHandler.enemyAnimator.SetBool("isInteracting", true);
//enemyAnimationHandler.enemyAnimator.SetBool("isRecovering", false);
//cTimer += Time.deltaTime;
//if (cTimer > enemyManager.chargeTimer)
//{
//    cTimer = 0;
//    enemyAnimationHandler.enemyAnimator.SetBool("isCharging", true);
//    return chargeState;
//}
//enemyManager.FaceTarget();
//enemyAnimationHandler.enemyAnimator.SetBool("combatIdle", true);
//enemyAnimationHandler.enemyAnimator.applyRootMotion = true;
//float distance = Vector3.Distance(enemyManager.transform.position, enemyManager.currentTarget.transform.position);
//if (distance <= enemyManager.attackRange)
//{
//    cTimer = 0;
//    enemyAnimationHandler.enemyAnimator.SetBool("attack", true);
//    return attackState;
//}

//if (distance >= enemyManager.combatStanceStateRange)
//{
//    cTimer = 0;
//    enemyAnimationHandler.enemyAnimator.SetBool("combatIdle", false);
//    enemyAnimationHandler.enemyAnimator.SetBool("isCharging", false);
//    return pursueTargetState;
//}
//return this;
