using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class CharacterCollisionBlocker : MonoBehaviour
    {
        public CapsuleCollider characterCollider;
        public CapsuleCollider characterBlockerCollider;

        private void Start()
        {
            if (characterCollider != null && characterBlockerCollider != null)
            {
                Physics.IgnoreCollision(characterCollider, characterBlockerCollider, true);
            }
        }
    }
}