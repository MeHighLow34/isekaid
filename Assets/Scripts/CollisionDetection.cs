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
            if (other.gameObject.tag != "Enemy") return;
            EnemyManager enemy = other.GetComponent<EnemyManager>();
            if(enemy.currentState == attackState)
            {
              //  enemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
            else
            {
                enemy.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                enemy.enemyAnimationHandler.PlayTargetAnimation("Hit", true);
            }
        }
    }
}
