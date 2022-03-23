using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class InputManager : MonoBehaviour
    {
        PlayerAttacker playerAttacker;
        PlayerActions playerActions;
        [Header("Bools")]
        public bool lightAttack;
        public bool abilityAttack;
        [Header("Dependencies")]
        public PlayerManager playerManager;
        public AbilityManager abilityManager;
        [Header("Flags")]
        public bool comboFlag;
        private void Awake()
        {
            abilityManager = GetComponent<AbilityManager>();
            playerManager = GetComponent<PlayerManager>();  
            playerAttacker = GetComponent<PlayerAttacker>();
        }
        private void OnEnable()
        {
            if(playerActions == null)
            {
                playerActions = new PlayerActions();
                playerActions.Action.Attack.performed += ctx => lightAttack = true; 
                playerActions.Action.AbilityAttack.performed += ctx => abilityAttack = true;    

            }
            playerActions.Enable();
        }



        private void OnDisable()
        {
            playerActions.Disable();
        }

        public void HandleAllInput()
        {
            HandleAttackInput();
            HandleAbilityInput();
        }
        public void HandleAttackInput()
        {
            if (lightAttack)
            {
                if(playerManager.canDoCombo)
                {
                    comboFlag = true;
                    playerAttacker.HandleLightAttackCombo();
                    comboFlag = false;
                }
                else
                {
                    if (playerManager.isInteracting)
                    {
                        lightAttack = false;
                        return;
                    }
                    playerAttacker.HandleLightAttack();
                }


                //if(playerManager.isInteracting)
                //{
                //    lightAttack = false;
                //    return;
                //}

                //playerAttacker.HandleLightAttack();
                //lightAttack = false;
                lightAttack = false;
            }
        }

        private void HandleAbilityInput()
        {
            if(abilityAttack)
            {
                abilityManager.currentAbility.UseAbility();
                abilityAttack = false;
            }
        }
    }
}