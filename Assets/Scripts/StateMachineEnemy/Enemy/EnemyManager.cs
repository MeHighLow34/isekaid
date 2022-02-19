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
        [Header("Bools")]
        public bool isInteracting;
        public bool isRecovering;
        public bool suckedByBlackHole = false;
        public bool isDead;
        [Header("Shooting")]
        public Transform attackPosition;
        public Projectile bullet;
        public float shootingForce;
        public bool strafeLeft;
        public bool strafeRight;

        public Transform hands;
        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            enemyAnimationHandler = GetComponent<EnemyAnimationHandler>();  
        }
        private void Update()
        {
            CheckIfDead();  // If we die we turn on ragDoll
                            // VelocityEquator();// So that the locomotion animations actually play
                            //   UpdateLocomotionAnimation();
            VelocityEquator();

        }
        private void  FixedUpdate()
        {
          //  VelocityEquator();
            RootMotionSetup(); //necessary if we want to play rootMotion animation on the enemy
            HandleStateMachine();   // State Machine
        }

        private void LateUpdate()
        {
          //  VelocityEquator();
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

        private void RootMotionSetup() //necessary if we want to play rootMotion animation on the enemy
        {
            
            CheckIfRootMotionEnabled();
            CheckIsInteracting();
        }

        #region Root Motion Animation Setup
        private void CheckIfRootMotionEnabled()
        {
            if(enemyAnimationHandler.enemyAnimator.applyRootMotion == true)
            {
                GetComponent<Ragdoll>().disabled = true;
                enemyAnimationHandler.enemyAnimator.updateMode = AnimatorUpdateMode.AnimatePhysics;
            }
            else
            {
                enemyAnimationHandler.enemyAnimator.updateMode = AnimatorUpdateMode.Normal;
                GetComponent<Ragdoll>().disabled = false;
            }
            
        }
        private void CheckIsInteracting()
        {
            isInteracting = enemyAnimationHandler.enemyAnimator.GetBool("isInteracting");
            if(isInteracting)
            {
                navMeshAgent.enabled = false; // We don't want to  move when we are using Root Motion animation Obviously...
            }
        }
        #endregion
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
                enemyAnimationHandler.enemyAnimator.SetFloat("Speed", enemyRb.velocity.magnitude); // Setting the animationFloat to the speed of our movement...
            }
        }



        public void FaceTarget()
        {
            Vector3 direction = currentTarget.transform.position - transform.position;
            direction.y = transform.position.y;
            Quaternion lookRotation = Quaternion.LookRotation(direction).normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationDelay * Time.deltaTime);

        }

        private void AnimatorBoolsEquator()
        {
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
        public void Shoot()
        {
          attackPosition.LookAt(currentTarget.transform.position);
          var newBullet =  Instantiate(bullet, attackPosition.transform.position, Quaternion.identity);
          newBullet.GetComponent<Rigidbody>().AddForce(attackPosition.transform.forward * shootingForce, ForceMode.Impulse);

        }



        #endregion
    }


}
