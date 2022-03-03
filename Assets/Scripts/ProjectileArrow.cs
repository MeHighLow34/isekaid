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

        private void Start()
        {
            transform.LookAt(GetAimLocation());
            print("I have been spawneed");
        }

        private void Update()
        {
            if (target == null) return;
            if (isHoming)
            {
                transform.LookAt(GetAimLocation());
            }
            transform.Translate(Vector3.forward * Time.deltaTime * arrowSpeed);
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
