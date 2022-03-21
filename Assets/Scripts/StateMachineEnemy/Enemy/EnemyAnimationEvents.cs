using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class EnemyAnimationEvents : MonoBehaviour
    {
        EnemyAnimationHandler enemyAnimationHandler;
        EnemyColliderDisabler enemyColliderDisabler;
        [Header("Archer")]
        public GameObject arrowSpawnMagic;
        public GameObject arrowGameObject;
        public Transform arrowSpawnPosition;
        [Header("Basic Mage")]
        public GameObject magicBallGameObject;
        public Transform magicBallSpawnPosition;
        public float pushBackForce;
        public Vector3 pushBackVecto;
        public float pushBackRange;
        [Header("Knight")]
        public KnightAttackState knightAttackState;
        private void Awake()
        {
            enemyAnimationHandler = GetComponent<EnemyAnimationHandler>();
            enemyColliderDisabler = GetComponent<EnemyColliderDisabler>();
        }
        private void LateUpdate()
        {
            //if (enemyColliderDisabler.punkHeartCollider != null)
            //{
            //    bool isVulnerable = enemyAnimationHandler.enemyAnimator.GetBool("isVulnerable");
            //    enemyColliderDisabler.punkHeartColliderState = isVulnerable;    
            //}
        }
        public void DisableAttack()
        {
            GetComponent<EnemyAnimationHandler>().enemyAnimator.SetBool("attack", false);
        }
        public void EnableLeftHandCollider()
        {
            enemyColliderDisabler.leftHandColliderState = true;
        }

        public void DisableLeftHandCollider()
        {
            enemyColliderDisabler.leftHandColliderState = false;
        }

        public void EnableRightHandCollider()
        {
            enemyColliderDisabler.rightHandColliderState = true;
        }

        public void DisableRightHandCollider()
        {
            enemyColliderDisabler.rightHandColliderState = false;    
        }
        #region Punk Heart
        #endregion
        public void ShootArrow()
        {
            var arrow =  Instantiate(arrowGameObject, arrowSpawnPosition.position, Quaternion.identity);
            arrow.GetComponent<ProjectileArrow>().target = GetComponent<EnemyManager>().currentTarget.transform;
        }
        public void ArrowMagic()
        {
            Instantiate(arrowSpawnMagic, arrowSpawnPosition.position, Quaternion.identity);
        }
        public void ShootMagicBall()
        {
            var magicBall = Instantiate(magicBallGameObject, magicBallSpawnPosition.position, Quaternion.identity);
            magicBall.GetComponent<MagicProjectiles>().target = GetComponent<EnemyManager>().currentTarget.transform;
        }

        public void PushPlayerBack()
        {
            float distanceFromPlayer = Vector3.Distance(GetComponent<EnemyManager>().transform.position, GetComponent<EnemyManager>().currentTarget.transform.position);
            if (distanceFromPlayer <= pushBackRange)
            {
                PlayerMovement playerMovement = GetComponent<EnemyManager>().currentTarget.GetComponent<PlayerMovement>();
                playerMovement.Jump(pushBackVecto, pushBackForce / Time.deltaTime);
            }
        }

        public void LookAtPlayerKnight()
        {
            knightAttackState.followsTarget = true;
        }
    }
}