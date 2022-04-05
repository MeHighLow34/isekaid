using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class DeathFix : MonoBehaviour
    {
        EnemyManager enemyManager;
        Animator animator;
        Ragdoll ragdoll;
        public GameObject userInterface;
        public BoxCollider[] colliders;
        private void Awake()
        {
            ragdoll = GetComponent<Ragdoll>();
            enemyManager = GetComponent<EnemyManager>();
            animator = GetComponent<Animator>();
        }
        private void Update()
        {
            if(enemyManager.isDead)
            {
                ragdoll.disabled = false;
                animator.SetBool("isInteracting", false);
                userInterface.SetActive(false);
                foreach (var collider in colliders)
                {
                    if (collider == null) return;
                    collider.enabled = false;
                }
            }
        }
    }
}
