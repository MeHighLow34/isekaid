using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

namespace Isekai
{
    public class AnimationEvents : MonoBehaviour
    {
        [Header("Attacking")]
        public BoxCollider weaponBoxCollider;
        public Animator animator;
        public Transform weaponHolder;
       
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void GetWeapon()
        {
            weaponBoxCollider = weaponHolder.GetChild(0).GetComponent<BoxCollider>();
        }

        private void Update()
        {
          GetWeapon();
        }
        public void EnableCollider()
        {
            weaponBoxCollider.enabled = true;
        }

        public void DisableCollider()
        {
            weaponBoxCollider.enabled = false;
        }

        public void EnableCombo()
        {
            animator.SetBool("canDoCombo", true);
        }

        public void DisableCombo()
        {
            animator.SetBool("canDoCombo", false);
        }

       public void Shake()
       {
          CameraShaker.Instance.ShakeOnce(3.5f, 3f, .1f, 1f);
       }
    }
}
