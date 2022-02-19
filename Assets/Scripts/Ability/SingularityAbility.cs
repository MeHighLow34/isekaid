using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class SingularityAbility : Ability
    {
        [Header("Stats")]
        public GameObject blackHole;
        public Camera fpsCam;
        private Vector3 targetPosition;
        private void Awake()
        {
            abilityIntermediary = FindObjectOfType<AbilityIntermediary>();
            animationManager = FindObjectOfType<AnimationManager>();
            fpsCam = Camera.main;
        }
     
        private void Start()
        {
            beingUsed = false;
            time = timeLimit;
            canUse = true;
        }
        public override void UseAbility()
        {
            if (canUse == false) return;
            Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                //print(hit.transform.gameObject.name);
                targetPosition = hit.point;
                abilityIntermediary.currentAbility = this;
                animationManager.PlayTargetAnimation("BlackHole", false);
                //Instantiate(blackHole, targetPosition, Quaternion.identity);
                //canUse = false;
                //time = timeLimit;

                // then we play ANIMATION...
            }
            else
            {
                return;
            }


        }

        public override void AnimationUse()
        {
            Instantiate(blackHole, targetPosition, Quaternion.identity);
            canUse = false;
            time = timeLimit;
        }

        private void Timer()
        {
            time -= Time.deltaTime;         // Just counts down with time and once it reaches zero we canUse ability again...
            if (time <= 0)
            {
                canUse = true;
                time = 0;
            }
        }

        private void Update()
        {
            if (canUse == false)      // Once we have used the ability we start a timer
            {
                Timer();
            }
        }

    }
}
