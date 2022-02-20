using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Isekai
{
    public class EnemyManager : MonoBehaviour
    {
        [Header("Scripts")]
        public State currentState;
        public EnemyAnimationHandler enemyAnimationHandler;
        BaseStats enemyStats;
        public Rigidbody enemyRb;
        public NavMeshAgent navMeshAgent;
        [Header("Attack Action")]
        public EnemyAttackAction attack1;
        [Header("Rotation")]
        public float rotationDelay;
        [Header("Idle/Patrol Information")]
        public float detectionRadius;
        public float timeSinceLastSawPlayer;
        public float dwellTime;
        public float waypointTolerance;
        [Header("Pursue Target Information")]
        public float combatStanceStateRange;
        [Header("Combat Stance Information")]
        public float attackRange;
        [Header("Recovery Information")]
        public float recoveryTime;
        public float maxRecoveryTime;
        [Header("Charge")]
        public float chargeTimer;
        [Header("State Machine Info")]
        public BaseStats currentTarget;
        public LayerMask detectionLayer;
        public float escapeRange;
        public float tooCloseRange;
        public float distance;
        [Header("Bools")]
        public bool isInteracting;
        public bool isRecovering;
        public bool suckedByBlackHole = false;
        public bool isDead;
        public bool strafeLeft;
        public bool strafeRight;
        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            enemyAnimationHandler = GetComponent<EnemyAnimationHandler>();  
        }
        private void Update()
        {
            CheckIfDead();
            VelocityEquator();
        }
        private void  FixedUpdate()
        {
            RootAnimationChecker();
            HandleStateMachine(); 
        }
        private void LateUpdate()
        {
            AnimatorBoolsEquator();
            UpdateLocomotionAnimation();
        }
        private void HandleStateMachine()
        {
            if(currentState != null)
            {
                State nextState = currentState.Tick(this, enemyStats, enemyAnimationHandler);
                if(nextState != null)
                {
                    SwitchToNextState(nextState);
                }
            }
        }
        private void RootAnimationChecker()
        {
            if (isInteracting)  // Apply Root Motion
            {
                enemyAnimationHandler.enemyAnimator.applyRootMotion = true;
                enemyAnimationHandler.enemyAnimator.updateMode = AnimatorUpdateMode.AnimatePhysics;
                navMeshAgent.enabled = false;
                GetComponent<Ragdoll>().disabled = true;
            }
            else  // Let the NavMeshAgent take over
            {
                enemyAnimationHandler.enemyAnimator.applyRootMotion = false;
                enemyAnimationHandler.enemyAnimator.updateMode = AnimatorUpdateMode.Normal;
                navMeshAgent.enabled = true;
                GetComponent<Ragdoll>().disabled = false;   
            }
        }
        private void SwitchToNextState(State nextState)
        {
            currentState = nextState;
        }

        private void VelocityEquator()  // Rigidbody velocity is same as how much we are moving with the navmeshagent...Smooth movement
        {
            Vector3 targetVelocity = navMeshAgent.velocity;
            enemyRb.velocity = targetVelocity;
        }
        private void UpdateLocomotionAnimation()
        {
            if (suckedByBlackHole)  // What animation we should play when we are getting sucked by black hole
            {
                enemyAnimationHandler.PlayTargetAnimation("Locomotion", false);
                enemyAnimationHandler.enemyAnimator.SetFloat("Speed", 5.5f);

            }
            else
            {
                enemyAnimationHandler.enemyAnimator.SetFloat("Speed", enemyRb.velocity.magnitude); // Setting the animationFloat to the speed of our movement for cleaner animation.
            }
        }
        private void AnimatorBoolsEquator()
        {
            isInteracting = enemyAnimationHandler.enemyAnimator.GetBool("isInteracting");
            isRecovering = enemyAnimationHandler.enemyAnimator.GetBool("isRecovering");
        }
        #region Animation Event

        public void TurnOnRecovery()
        {
            enemyAnimationHandler.enemyAnimator.SetBool("isRecovering", true);
        }

        public void EnableCombo()
        {
            enemyAnimationHandler.enemyAnimator.SetBool("canDoCombo", true);
        }
        private void CheckIfDead()
        {
            if(isDead)
            {
                GetComponent<Ragdoll>().state = true; // If we die we turn on ragDoll
            }
        }
        #endregion
        public void FaceTarget()
        {
            Vector3 direction = currentTarget.transform.position - transform.position;
            direction.y = transform.position.y;
            Quaternion lookRotation = Quaternion.LookRotation(direction).normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationDelay * Time.deltaTime);
        }
        public float DistanceToEnemy()
        {
            distance = Vector3.Distance(transform.position, currentTarget.transform.position);
            return distance;
        }

        #region Gizmos

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }

        #endregion
    }


}
