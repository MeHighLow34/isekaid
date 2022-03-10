using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class EnemyColliderDisabler : MonoBehaviour
    {
        [Header("Colliders")]
        [SerializeField] BoxCollider leftHandCollider;
        [SerializeField] BoxCollider rightHandCollider;
        [SerializeField] public BoxCollider punkHeartCollider;
        [Header("Bools")]
        public bool leftHandColliderState;
        public bool rightHandColliderState;
        public bool punkHeartColliderState;   

        private void LateUpdate()
        {
            if(leftHandCollider != null)
            {
                leftHandCollider.enabled = leftHandColliderState;
            }
            if (rightHandCollider != null)
            {
                rightHandCollider.enabled = rightHandColliderState;
            }
            if(punkHeartCollider != null)
            {
                punkHeartCollider.enabled = punkHeartColliderState;
            }
        }
    }
}
