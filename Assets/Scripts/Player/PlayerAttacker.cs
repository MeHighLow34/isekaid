using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Isekai
{
    public class PlayerAttacker : MonoBehaviour
    {
        AnimationManager animationManager;
        public string lastAttack;

        private void Awake()
        {
            animationManager = GetComponent<AnimationManager>();
        }


        public void HandleLightAttack()
        {
            animationManager.PlayTargetAnimation("Attack1", true);
        }
    }
}
