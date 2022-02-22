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
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Throwable")
            {
                other.GetComponent<Rigidbody>().AddForce(other.transform.forward * force, ForceMode.Impulse); 
            }
            if (other.gameObject.tag == "EnemyDamagePoint")
            {
                other.GetComponentInParent<EnemyHealth>().TakeDamage(damage);
                var enemyAnimation = other.GetComponentInParent<EnemyAnimationHandler>();
                enemyAnimation.PlayTargetAnimation("Hit", true);
            }
           
        }
    }
}
