using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class SingularityAbility : Ability
    {
        AbilityManager abilityManager;
        [Header("Stats")]
        public GameObject blackHole;
        public Camera fpsCam;
        private Vector3 targetPosition;
        public float cooldownTimer = 15f;
        private void Awake()
        {
            abilityManager = FindObjectOfType<AbilityManager>();
            abilityIntermediary = FindObjectOfType<AbilityIntermediary>();
            animationManager = FindObjectOfType<AnimationManager>();
            fpsCam = Camera.main;
        }
        public override void UseAbility()
        {
            if(abilityManager.abilitiesDisabled == true)
            {
                print("Can't use it anymore");
                return;
            }
            Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                targetPosition = hit.point;
                abilityIntermediary.currentAbility = this;
                animationManager.PlayTargetAnimation("BlackHole", false);
                abilityManager.StartTimer(cooldownTimer);
            }
            else
            {
                return;
            }

            // something
        }
        public override void AnimationUse()
        {
            Instantiate(blackHole, targetPosition, Quaternion.identity);
        }

    }
}
