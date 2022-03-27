using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class CollisionDetection : MonoBehaviour
    {
        public GameObject player;
        public float force;
        public float damage;
        public  AttackState attackState;
        public CharacterClass enemyBeingHit;
        [Header("VFX")]
        public GameObject bloodVFX;
        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        private void OnTriggerEnter(Collider other)
        {
            
            if(other.gameObject.tag == "Throwable")
            {
                other.GetComponent<Rigidbody>().AddForce(other.transform.forward * force, ForceMode.Impulse); 
            }
            if (other.gameObject.tag == "EnemyDamagePoint")  // This is specific case for Punk
            {
                other.GetComponentInParent<EnemyHealth>().TakeDamage(damage);
                var enemyAnimation = other.GetComponentInParent<EnemyAnimationHandler>();
                enemyAnimation.PlayTargetAnimation("Hit", true);
                if(other.GetComponentInParent<EnemyHealth>().manager.currentTarget == null)
                {
                    float fullDamage = other.GetComponentInParent<BaseStats>().GetStat(Stat.Health);
                    other.GetComponentInParent<EnemyHealth>().TakeDamage(fullDamage);
                }
                return;
            }
            enemyBeingHit = other.GetComponent<BaseStats>().characterClass;
            if (other.gameObject.tag == "Enemy" && enemyBeingHit != CharacterClass.Soldier)
            {
                
                other.GetComponentInParent<EnemyHealth>().TakeDamage(damage);
                other.GetComponentInParent<EnemyHealth>().manager.currentTarget = player.transform.GetComponent<BaseStats>();

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
