using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Isekai
{
    public class Ragdoll : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Animator animator = null;
        [SerializeField] public Transform ragdollHolder;
        [SerializeField] public Rigidbody parentRigidBody = null;
        [SerializeField] public NavMeshAgent agent;
        [SerializeField] public Collider capsuleCollider = null;
        [Header("Exceptions")]
        [SerializeField] public CapsuleCollider exceptionCollider;
        [SerializeField] public BoxCollider exceptCollider;
        [SerializeField] public BoxCollider exception3DamageCollider;
        [SerializeField] public CapsuleCollider realExceptionCharacterBlockerCollider;
        [Header("Animation Event Exceptions")]
        [SerializeField] BoxCollider leftHandCollider;
        private Rigidbody[] ragdollBodies;
        private Collider[] ragdollColliders;
        private CharacterJoint[] ragdollJoints;
        public bool state = false;

        public bool disabled;
        private void Start()
        {
            ragdollBodies = ragdollHolder.GetComponentsInChildren<Rigidbody>();
            ragdollColliders = ragdollHolder.GetComponentsInChildren<Collider>();
            ragdollJoints = ragdollHolder.GetComponentsInChildren<CharacterJoint>();
            foreach (CharacterJoint characterJoint in ragdollJoints)
            {
                characterJoint.enableProjection = true;
            }
        }

        private void FixedUpdate()
        {
            if (disabled) return;
            if(state == true)
            {
                TurnOnRagdoll();

            }
            else
            {
                TurnOffRagdoll();
                Exceptions();
                if(realExceptionCharacterBlockerCollider != null) realExceptionCharacterBlockerCollider.enabled = true;
            }

            
        }
        

        private void Exceptions()
        {
            if(leftHandCollider != null)
            {
                leftHandCollider.enabled = false;
            }
            if (exceptCollider != null)
            {
                exceptionCollider.enabled = true;
                exceptCollider.enabled = true;
            }
            if (exception3DamageCollider != null) exception3DamageCollider.enabled = true;
        }
        

        public void TurnOnRagdoll()
        {
            capsuleCollider.isTrigger = true;
            animator.enabled = false;
            foreach(Rigidbody rb in ragdollBodies)
            {
                rb.isKinematic = false;
            }

            CharacterJoint[] characterJoints = ragdollHolder.GetComponentsInChildren<CharacterJoint>();
            foreach(CharacterJoint characterJoint in characterJoints)
            {
                characterJoint.enableProjection = true;
            }

            foreach(Collider collider in ragdollColliders)
            {
                collider.enabled = true;
            }
            if (parentRigidBody != null)
            {
                parentRigidBody.isKinematic = true;
            }
            agent.enabled = false;
        }

        public void TurnOffRagdoll()
        {
            animator.enabled = true;
            foreach (Rigidbody rb in ragdollBodies)
            {
                rb.isKinematic = true;
            }

            foreach (Collider collider in ragdollColliders)
            {
                collider.enabled = false;
            }
            if (parentRigidBody != null)
            {
                parentRigidBody.isKinematic = false;
            }
            agent.enabled = true;
            capsuleCollider.isTrigger = false;
            capsuleCollider.enabled = true;
        }


    }
}
