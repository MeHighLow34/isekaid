using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Isekai
{
    public class DisplayPlayerHealth : MonoBehaviour
    {
        public Image image;
        public Health playerHealth;

        private void Update()
        {
            image.fillAmount = playerHealth.GetDecimal(); // ds
        }
    }
}
