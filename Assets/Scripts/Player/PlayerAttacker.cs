using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Isekai
{
    public class PlayerAttacker : MonoBehaviour
    {

        InputManager inputManager;
        AnimationManager animationManager;
        public string lastAttack;

        private void Awake()
        {
            inputManager = GetComponent<InputManager>();    
            animationManager = GetComponent<AnimationManager>();
        }


        public void HandleLightAttack()
        {
            animationManager.PlayTargetAnimation("Attack1", true);
            lastAttack = "Attack1";
        }

        public void HandleLightAttackCombo()
        {
            if(inputManager.comboFlag)
            {
                if(lastAttack == "Attack1")
                {
                    animationManager.PlayTargetAnimation("Attack2", true);
                    lastAttack = "Attack2";
                }
            }
        }
    }
}
