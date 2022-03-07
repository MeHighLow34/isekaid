using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class ProjectileArrow : MonoBehaviour
    {
        [SerializeField] public Transform target;
        [SerializeField] float arrowSpeed = 3f;
        [SerializeField] LayerMask ignoreLayer;
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
            if(isMagic)
            {
                explosionTimer -= Time.deltaTime;
            }
            if (isHoming)
            {
                transform.LookAt(GetAimLocation());
            }
            transform.Translate(Vector3.forward * Time.deltaTime * arrowSpeed);
            if(explosionTimer <= 0)
            {
                Destroy(gameObject);
            }
        }
        private Vector3 GetAimLocation()
        {
            var targetCapsule = target.GetComponent<CharacterController>();
            return target.position + Vector3.up * targetCapsule.height / 2;
        }


        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.layer == ignoreLayer)
            {
                return;
            }
            Destroy(gameObject);
        }
    }
}
