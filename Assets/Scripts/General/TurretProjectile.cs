using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class TurretProjectile : MonoBehaviour
    {
        [SerializeField] public Transform target;
        [SerializeField] float speed = 3f;
        public bool isHoming;
        private void Start()
        {
            transform.LookAt(GetAimLocation());
        }

        private void Update()
        {
            if (target == null) return;

            if (isHoming)
            {
                transform.LookAt(GetAimLocation());
            }
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        private Vector3 GetAimLocation()
        {
            var targetCapsule = target.GetComponent<CapsuleCollider>();
            return target.position + Vector3.up * targetCapsule.height / 2;
        }


        private void OnTriggerEnter(Collider other)
        {
            var enemyHealth = other.GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(5);
            }
            Destroy(gameObject);
        }
    }
}
