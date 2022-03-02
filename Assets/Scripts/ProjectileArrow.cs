using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class ProjectileArrow : MonoBehaviour
    {
        [SerializeField] public Transform target;
        [SerializeField] float arrowSpeed = 3f;
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
            transform.Translate(Vector3.forward * Time.deltaTime * arrowSpeed);
        }
        private Vector3 GetAimLocation()
        {
            var targetCapsule = target.GetComponent<CharacterController>();
            return target.position + Vector3.up * targetCapsule.height / 2;
        }


        private void OnCollisionEnter(Collision collision)
        {
            print("Hit Something I'm an Arrow");
            Destroy(gameObject);
        }
    }
}
