using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class EnemyAnimationEvents : MonoBehaviour
    {
        public BoxCollider leftHandCollider;
        
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

    }
}