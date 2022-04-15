using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Isekai
{
    public class PickUpInfo : MonoBehaviour
    {
        public CanvasGroup canvasGroup;
        public TextMeshProUGUI textMeshProUGUI;
        public float timer = 2f;
        bool startTimer;
        public void DisplayPickUp(string itemName)
        {
            canvasGroup.alpha = 1f;
            textMeshProUGUI.text = itemName;
            startTimer = true;
            timer = 2f;
        }

        private void Update()
        {
            if (startTimer)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    canvasGroup.alpha = 0f;
                    startTimer = false;
                }
            }
        }
    }
}
