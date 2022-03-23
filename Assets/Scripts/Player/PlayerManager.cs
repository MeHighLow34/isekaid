using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class PlayerManager : MonoBehaviour
    {
        [Header("Dependencies")]
        public AnimationManager animationManager;
        public PlayerLocomotion playerLocomotion;
        public PlayerMovement playerMovement;
        public InputManager inputManager;
        [Header("Bools")]
        public bool isInteracting;
        public bool canDoCombo;
        private void Awake()
        {
            inputManager = GetComponent<InputManager>();
            playerMovement = GetComponent<PlayerMovement>();
            animationManager = GetComponent<AnimationManager>();    
            playerLocomotion = GetComponent<PlayerLocomotion>();    
        }
        private void Update()
        {
            inputManager.HandleAllInput();
            playerLocomotion.AllLocomotion();   
        }

        private void LateUpdate()
        {
            UpdateAnimationBools();
        }


        private void UpdateAnimationBools()
        {
            animationManager.animator.SetBool("Grounded", playerMovement.grounded);
            isInteracting = animationManager.animator.GetBool("isInteracting");
            canDoCombo = animationManager.animator.GetBool("canDoCombo");
        }
    }
}
