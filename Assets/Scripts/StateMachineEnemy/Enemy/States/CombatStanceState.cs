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
                enemyManager.navMeshAgent.enabled = false;
                enemyAnimationHandler.enemyAnimator.SetBool("isInteracting", true);
                enemyAnimationHandler.enemyAnimator.SetBool("isRecovering", false);
                cTimer += Time.deltaTime;
                if(cTimer  > enemyManager.chargeTimer)
                {
                   cTimer = 0;
                   enemyAnimationHandler.enemyAnimator.SetBool("isCharging", true);
                   return chargeState;
                }
                enemyManager.FaceTarget();
                enemyAnimationHandler.enemyAnimator.SetBool("combatIdle", true);
                enemyAnimationHandler.enemyAnimator.applyRootMotion = true;
                float distance = Vector3.Distance(enemyManager.transform.position, enemyManager.currentTarget.transform.position);
                if(distance <= enemyManager.attackRange)
                {
                cTimer = 0;
                enemyAnimationHandler.enemyAnimator.SetBool("attack", true);
                return attackState;
                }

                if(distance >= enemyManager.combatStanceStateRange)
                {
                cTimer = 0;
                enemyAnimationHandler.enemyAnimator.SetBool("combatIdle", false);
                enemyAnimationHandler.enemyAnimator.SetBool("isCharging", false);
                return pursueTargetState;
                }
                return this;


            // Conditions for ROOT MOTION ANIMATION ARE applyROOTMOTION, navmeshagent DISABLED,  ANIMATOR HAS TO HAVE ANIMATE PHYSICS and in no way shape or form should it have isKinematic ENABLED..........Ok Imma work on that.......LET'S FUCKING GOOOOOO
             }
    }
}
