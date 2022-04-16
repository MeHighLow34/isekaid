using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class PlayerLocomotion : MonoBehaviour
    {
        [Header("Movement Animations")]
        public AnimationManager animationManager;
        public PlayerController playerController;
        public PlayerMovement playerMovement;
        public WeaponBobCSGO bobbing;
        public float bobbingAmount = 1.65f;
        public float normalBobbingAmount;
        private void Awake()
        {
            animationManager = GetComponent<AnimationManager>();
            playerMovement = GetComponent<PlayerMovement>();
            playerController = GetComponent<PlayerController>();    
        }

        public void AllLocomotion()
        {
            HandleLocomotion();
        }

        private void HandleLocomotion()
        {
            //if(playerMovement.grounded == false)
            //{
            //    if(playerController.status == Status.crouching || playerController.status == Status.sliding)
            //    {
            //        // When we are crouching we don't want to play jump animation obvio
            //        return;
            //    }
            //    animationManager.PlayTargetAnimation("Jump_Jumping", false);
            //    bobbing.stopped = true;
            //    return;
            //}

            if (playerController.status == Status.sprinting)
            {
                bobbing.stopped = false;
                bobbing.bobMultiplier = bobbingAmount;
            }
            else
            {
                bobbing.stopped = false;
                bobbing.bobMultiplier = normalBobbingAmount;
            }
        }
    }
}
