using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Isekai
{
    public class DisplayPlayerStamina : MonoBehaviour
    {
        public Image image;
        public PlayerController playerController;


        private void Update()
        {
            image.fillAmount = playerController.GetDecimal();
        }
    }
}
