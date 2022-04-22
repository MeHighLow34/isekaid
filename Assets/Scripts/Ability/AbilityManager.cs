using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

namespace Isekai 
{
    public class AbilityManager : MonoBehaviour
    {
        public Ability testingAbility;
        public Ability currentAbility;
        public Image icon;
        [Header("Pre-Alpha Abilities")]
        public Ability telekenesis;
        public Ability singularity;
        public Ability hypnotize;
        [Header("Timer Props")]
        public float time;
        public bool abilitiesDisabled;
        float timeMax;
        private void Start()
        {
            Setup(testingAbility);
        }
        private void Setup(Ability ability)
        {
            if (ability.beingUsed)
            {
                print("Can't change when the current ability is in use");
                return;
            }
            currentAbility = ability;
            icon.sprite = currentAbility.icon;
        }

        private void Update()
        {
            Timer();
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Setup(telekenesis);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Setup(singularity);
            }

            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                Setup(hypnotize);
            }
        }

        public void StartTimer(float timeValue)
        {
            timeMax = timeValue;
            time = timeValue;
            abilitiesDisabled = true;
        }

        private void Timer()
        {
            if(abilitiesDisabled)
            {
                time -= Time.deltaTime;
                if(time <= 0 )
                {
                    abilitiesDisabled = false;
                }
            }
        }

        public float GetDecimals()
        {
            return time / timeMax;
        }
    }
}
