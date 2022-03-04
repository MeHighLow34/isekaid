using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class EnemyColliderDisabler : MonoBehaviour
    {
        [Header("Colliders")]
        [SerializeField] BoxCollider leftHandCollider;
        [Header("Bools")]
        public bool leftHandColliderState;

        private void LateUpdate()
        {
            if(leftHandCollider != null)
            {
                leftHandCollider.enabled = leftHandColliderState;
            }
        }
    }
}
