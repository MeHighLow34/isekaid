using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

        private void Start()
        {
            weaponBoxCollider = weaponHolder.GetChild(0).GetComponent<BoxCollider>();
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

        public void EnableCombo()
        {
            animator.SetBool("canDoCombo", true);
        }

        public void DisableCombo()
        {
            animator.SetBool("canDoCombo", false);
        }
    }
}
