
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Isekai
{
    public class AttackState : State
    {
        public RecoveryState recoveryState;
        bool played = false;
        public override State Tick(EnemyManager enemyManager, BaseStats enemyStats, EnemyAnimationHandler enemyAnimationHandler)
        {
            enemyManager.FaceTarget();
            enemyManager.attackRange = enemyManager.attack1.distanceRequirement;
            enemyManager.recoveryTime = enemyManager.attack1.recoveryTime;
            enemyManager.maxRecoveryTime = enemyManager.attack1.recoveryTime;
            enemyAnimationHandler.enemyAnimator.applyRootMotion = false;
            enemyAnimationHandler.enemyAnimator.updateMode = AnimatorUpdateMode.Normal;
            if (played == false)
            {
                enemyAnimationHandler.PlayTargetAnimation(enemyManager.attack1.animationName, true);
                played = true;
            }
            if (enemyManager.isRecovering)
            {
                played = false;
                return recoveryState;
            }

            return this;
            //float distance = Vector3.Distance(enemyManager.transform.position, enemyManager.currentTarget.transform.position);
            //if(distance <= enemyManager.escapeRange)
            //{
            //    InvokeRepeating("MoveALittle(enemyManager)", 0.05f, 5f);
            //    enemyManager.transform.LookAt(enemyManager.currentTarget.transform.position);
            //    enemyManager.enemyAnimationHandler.enemyAnimator.SetBool("Shooting", true);
            //    return this;
            //}
            //else
            //{
            //    enemyManager.enemyAnimationHandler.enemyAnimator.SetBool("Shooting", false);
            //    enemyManager.navMeshAgent.enabled = true;


            //    return pursueTargetState;
            //}




        }

        //    //private void MoveALittle(EnemyManager enemyManager)
        //    //{
        //    //    Vector3 newPosition = new Vector3(Random.Range(-range, range), 0f, Random.Range(-range, range));
        //    //    enemyManager.navMeshAgent.SetDestination(newPosition);
        //    //}

        //    #region Strafin/Test Code
        //    private bool EnemyInSight(EnemyManager enemyManager)
        //    {
        //        RaycastHit hit;
        //        if(Physics.Linecast(enemyManager.transform.position, enemyManager.currentTarget.transform.position, out hit))
        //        {
        //            if (hit.transform.tag == "Player")
        //            {

        //                return false;
        //            }
        //            else
        //            {
        //                if(hit.transform.name == gameObject.name)
        //                {
        //                    return false;
        //                }
        //                return true;
        //            }
        //        }
        //        else
        //        {
        //            print("Unreachable???");
        //            return false;
        //        }
        //    }
        //    private void Strafing(EnemyManager enemyManager)
        //    {
        //        Timer(enemyManager);
        //        if (enemyManager.strafeLeft)
        //        {
        //            StrafeLeft(enemyManager);
        //            StrafinConditions(enemyManager);
        //        }
        //        else if (enemyManager.strafeRight)
        //        {
        //            StrafeRight(enemyManager);
        //            StrafinConditions(enemyManager);
        //        }
        //    }
        //    private void Timer(EnemyManager enemyManager)
        //    {
        //        timer -= Time.deltaTime;
        //        if(timer <= 0)
        //        {
        //            if(enemyManager.strafeRight)
        //            {

        //                if ( !enemyManager.navMeshAgent.hasPath && enemyManager.navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete)
        //                {
        //                    Debug.Log("Character stuck");
        //                   enemyManager.navMeshAgent.enabled = false;
        //                   enemyManager.navMeshAgent.enabled = true;
        //                    Debug.Log("navmesh re enabled");
        //                    // navmesh agent will start moving again
        //                }

        //                enemyManager.strafeRight = false;
        //                enemyManager.strafeLeft = true;
        //            }else if(enemyManager.strafeLeft)
        //            {
        //                if (!enemyManager.navMeshAgent.hasPath && enemyManager.navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete)
        //                {
        //                    Debug.Log("Character stuck");
        //                    enemyManager.navMeshAgent.enabled = false;
        //                    enemyManager.navMeshAgent.enabled = true;
        //                    Debug.Log("navmesh re enabled");
        //                    // navmesh agent will start moving again
        //                }
        //                enemyManager.strafeLeft = false;
        //                enemyManager.strafeRight = true;

        //            }
        //            timer = Random.Range(3f, 12f);
        //        }
        //    }

        //    private void StrafinConditions(EnemyManager enemyManager)
        //    {

        //        enemyManager.enemyRb.velocity = Vector3.zero;
        //        enemyManager.enemyAnimationHandler.enemyAnimator.SetBool("Strafing", true);
        //        enemyManager.navMeshAgent.speed = 1.85f;
        //        enemyManager.transform.LookAt(enemyManager.currentTarget.transform.position);

        //    }
        //    private void StrafeLeft(EnemyManager enemyManager)
        //    {
        //        var offsetPlayer = transform.position - enemyManager.currentTarget.transform.position;
        //        var dir = Vector3.Cross(offsetPlayer, Vector3.up);
        //        enemyManager.navMeshAgent.SetDestination(transform.position + dir);
        //        var lookPos = enemyManager.currentTarget.transform.position - transform.position;
        //        lookPos.y = 0;
        //        var rotation = Quaternion.LookRotation(lookPos);
        //        enemyManager.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 12f);
        //    }

        //    private void StrafeRight(EnemyManager enemyManager)
        //    {
        //        var offsetPlayer = enemyManager.currentTarget.transform.position - transform.position;
        //        var dir = Vector3.Cross(offsetPlayer, Vector3.up);
        //        enemyManager.navMeshAgent.SetDestination(transform.position + dir);
        //        var lookPos = enemyManager.currentTarget.transform.position - transform.position;
        //        lookPos.y = 0;
        //        var rotation = Quaternion.LookRotation(lookPos);
        //        enemyManager.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 12f);
        //    }
        //    #endregion
        //}
    }
}