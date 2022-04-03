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
           //     animator.enabled = false;
                ragdoll.disabled = false;
                animator.SetBool("isInteracting", false);
            }
        }
    }
}
