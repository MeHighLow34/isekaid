using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Isekai
{
    public class MagicProjectiles : MonoBehaviour
    {
        [SerializeField] public Transform target;
        [SerializeField] float projectileSpeed = 3f;
        [SerializeField] LayerMask ignoreLayer;
        [SerializeField] GameObject explosionVFX;
        public bool isHoming;
        [Header("Magic Ball Properties")]
        public float explosionTimer;
        public bool isMagic;
        private void Start()
        {
            transform.LookAt(GetAimLocation());
        }

        private void Update()
        {
            if (target == null) return;
            if (isMagic)
            {
                explosionTimer -= Time.deltaTime;
            }
            if (isHoming)
            {
                transform.LookAt(GetAimLocation());
            }
            transform.Translate(Vector3.forward * Time.deltaTime * projectileSpeed);
            if (explosionTimer <= 0)
            {
                Explosion();
            }
        }
        private Vector3 GetAimLocation()
        {
            var targetCapsule = target.GetComponent<CharacterController>();
            return target.position + Vector3.up * targetCapsule.height / 2;
        }


        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == target.gameObject.tag)
            {
                Explosion();   
            }
        }


        private void Explosion()
        {
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}