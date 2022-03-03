using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class EnemyAnimationEvents : MonoBehaviour
    {
        public BoxCollider leftHandCollider;
        public GameObject arrowGameObject;
        public Transform arrowSpawnPosition;
        public void DisableAttack()
        {
            GetComponent<EnemyAnimationHandler>().enemyAnimator.SetBool("attack", false);
        }
        public void EnableLeftHandCollider()
        {
            leftHandCollider.enabled = true;
        }

        public void DisableLeftHandCollider()
        {
            leftHandCollider.enabled = false;
        }

        public void ShootArrow()
        {
            var arrow =  Instantiate(arrowGameObject, arrowSpawnPosition.position, Quaternion.identity);
            arrow.GetComponent<ProjectileArrow>().target = GetComponent<EnemyManager>().currentTarget.transform;
        }
    }
}