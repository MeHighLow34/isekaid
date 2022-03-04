using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class EnemyAnimationEvents : MonoBehaviour
    {
        EnemyColliderDisabler enemyColliderDisabler;
        public GameObject arrowGameObject;
        public Transform arrowSpawnPosition;

        private void Awake()
        {
            enemyColliderDisabler = GetComponent<EnemyColliderDisabler>();
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

        public void ShootArrow()
        {
            var arrow =  Instantiate(arrowGameObject, arrowSpawnPosition.position, Quaternion.identity);
            arrow.GetComponent<ProjectileArrow>().target = GetComponent<EnemyManager>().currentTarget.transform;
        }
    }
}