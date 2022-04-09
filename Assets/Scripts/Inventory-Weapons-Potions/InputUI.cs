using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Isekai
{
    public class InputUI : MonoBehaviour
    {
        public CanvasGroup HUD;
        public CanvasGroup inventoryCanvas;
        public bool inventoryEnabled;
        public CameraMovement cameraMovement;
        public GameObject blur;
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                inventoryEnabled = !inventoryEnabled;
            }

            if(inventoryEnabled)
            {
                HUD.alpha = 0f;
                inventoryCanvas.alpha = 1f;
                cameraMovement.enableCursor = true;
                cameraMovement.lockCursor = false;
                blur.SetActive(true);
            }
            else
            {
                HUD.alpha = 1f;
                inventoryCanvas.alpha = 0f;
                cameraMovement.enableCursor= false;
                cameraMovement.lockCursor = true;
                blur.SetActive(false);
            }

           
        }

    }
}
