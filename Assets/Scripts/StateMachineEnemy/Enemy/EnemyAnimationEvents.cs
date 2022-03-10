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
        private void Awake()
        {
            enemyAnimationHandler = GetComponent<EnemyAnimationHandler>();
            enemyColliderDisabler = GetComponent<EnemyColliderDisabler>();
        }
        private void LateUpdate()
        {
            if (enemyColliderDisabler.punkHeartCollider != null)
            {
                bool isVulnerable = enemyAnimationHandler.enemyAnimator.GetBool("isVulnerable");
                enemyColliderDisabler.punkHeartColliderState = isVulnerable;    
            }
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
    }
}