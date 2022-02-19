using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class BlackHole : MonoBehaviour
    {
        [Header("Properties")]
        public float power;
        public float attractionRange;
        public LayerMask attrackedTo;
        private Rigidbody rb;
        Collider[] hits;
        [Header("Explosion Property")]
        public float lifeTime;
        public GameObject explosionVFX;
        public float explosionRange;
        public float explosionForce;
        //public EnemyManager[] enemiesCaughtInBlackHole;
        public float damage;
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            hits = Physics.OverlapSphere(transform.position, attractionRange, attrackedTo);
            //foreach (var hit in hits)
            //{
            //    if (hit.transform.gameObject.GetComponent<EnemyManager>() != null)
            //    {
            //        hit.GetComponent<EnemyManager>().navMeshAgent.enabled = false;
            //        hit.GetComponent<EnemyManager>().suckedByBlackHole = true;  // If we find enemies in our overlap sphere we turn on suckedByBlackHole so we can play that animation...Later it will be Bool...
            //    }
            //    Vector3 direction = transform.position - hit.transform.position;
            //    hit.GetComponent<Rigidbody>().AddForce(direction.normalized * power, ForceMode.Acceleration);
            //}
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0)
            {
                
                Explode();
            }
        }

        private void Explode()
        {
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Collider[] objects = Physics.OverlapSphere(transform.position, explosionRange);
            for (int i = 0; i < objects.Length; i++)
            {
                var newObject = objects[i].GetComponent<Rigidbody>();
                if (newObject != null)
                {
                    //if (newObject.GetComponent<EnemyManager>() != null)
                    //{
                    //    newObject.GetComponent<EnemyManager>().suckedByBlackHole = false; // We turn off suckedByBlackHole animatinon
                    //    newObject.GetComponent<EnemyHealth>().TakeDamage(damage); // Enemy takes damage
                    //    newObject.GetComponent<EnemyManager>().enemyAnimationHandler.PlayTargetAnimation("Hit", true);  // We play rootMotion animation of Hit so that is seems more realistic...
                    //}
                    //else
                    //{
                    if (newObject.gameObject.tag == "Weapon") return;
                        newObject.AddExplosionForce(explosionForce, transform.position, explosionRange);
                    //}
                }
            }
            Invoke("Delay", 0.15f);
        }

        private void Delay()
        {
            Destroy(gameObject);
        }

    }
}
