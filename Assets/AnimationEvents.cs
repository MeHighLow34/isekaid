using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class AnimationEvents : MonoBehaviour
    {
        [Header("Attacking")]
        public BoxCollider weaponBoxCollider;


        private void Start()
        {
            weaponBoxCollider.enabled = false;
        }

        public void EnableCollider()
        {
            weaponBoxCollider.enabled = true;
        }

        public void DisableCollider()
        {
            weaponBoxCollider.enabled = false;
        }
    }
}
