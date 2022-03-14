using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class CollisionDetection : MonoBehaviour
    {
        public float force;
        public float damage;
        public  AttackState attackState;
        public CharacterClass enemyBeingHit;
        [Header("VFX")]
        public GameObject bloodVFX;
        private void OnTriggerEnter(Collider other)
        {
            //print(other.gameObject.name);
            if(other.gameObject.tag == "Throwable")
            {
                other.GetComponent<Rigidbody>().AddForce(other.transform.forward * force, ForceMode.Impulse); 
            }
            if (other.gameObject.tag == "EnemyDamagePoint")
            {
                other.GetComponentInParent<EnemyHealth>().TakeDamage(damage);
                var enemyAnimation = other.GetComponentInParent<EnemyAnimationHandler>();
                enemyAnimation.PlayTargetAnimation("Hit", true);
                return;
            }
            enemyBeingHit = other.GetComponent<BaseStats>().characterClass;
            if(enemyBeingHit == null)
            {
                enemyBeingHit = other.GetComponentInParent<BaseStats>().characterClass;
            }
            if (other.gameObject.tag == "Enemy" && enemyBeingHit != CharacterClass.Soldier)
            {
                print("hitting a full collider enemy");
                other.GetComponentInParent<EnemyHealth>().TakeDamage(damage);
                Instantiate(bloodVFX, other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position), Quaternion.identity);
                if (other.GetComponentInParent<EnemyManager>().hasHitReaction)
                {
                    var enemyAnimation = other.GetComponentInParent<EnemyAnimationHandler>();
                    enemyAnimation.enemyAnimator.SetBool("beingHit", true);
                }
            }
           
        }
    }
}
