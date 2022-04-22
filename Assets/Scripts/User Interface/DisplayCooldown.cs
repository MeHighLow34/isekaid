using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Isekai
{
    public class DisplayCooldown : MonoBehaviour
    {
        public Image image;
        public AbilityManager abilityManager;

        private void Awake()
        {
            abilityManager = FindObjectOfType<AbilityManager>();
        }

        private void Update()
        {
            image.fillAmount = abilityManager.GetDecimals();
        }

    }
}
