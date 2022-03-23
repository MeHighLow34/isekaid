using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class EnemyColliderDisabler : MonoBehaviour
    {
        [Header("Colliders-Punk")]
        [SerializeField] BoxCollider leftHandCollider;
        [SerializeField] BoxCollider rightHandCollider;
        [SerializeField] public BoxCollider punkHeartCollider;
        [Header("Colliders-Knight")]
        [SerializeField] BoxCollider swordCollider;
        [Header("Bools")]
        public bool leftHandColliderState;
        public bool rightHandColliderState;
        public bool punkHeartColliderState;
        public bool knightSwordCollider;

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
            if(swordCollider != null)
            {
                swordCollider.enabled = knightSwordCollider;
            }
            
        }
    }
}
