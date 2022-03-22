using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class ThrowableProjectile : MonoBehaviour
    {
        public float damage;
        private void OnCollisionEnter(Collision collision)
        {

            if(collision.gameObject.tag == "Enemy")
            {
                print("Enemy is what I'm going for");
                EnemyHealth enemyHealth = collision.gameObject.GetComponentInParent<EnemyHealth>();
                enemyHealth.TakeDamage(damage);
                if (collision.gameObject.GetComponentInParent<EnemyManager>().hasHitReaction)
                {
                    var enemyAnimation = collision.gameObject.GetComponentInParent<EnemyAnimationHandler>();
                    enemyAnimation.enemyAnimator.SetBool("beingHit", true);
                }
            }
        }
    }
}