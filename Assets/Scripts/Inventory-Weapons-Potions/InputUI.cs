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
        public bool dialogueEnabled;
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                inventoryEnabled = !inventoryEnabled;
            }
            if (inventoryEnabled)
            {
                HUD.alpha = 0f;
                inventoryCanvas.alpha = 1f;
                EnableCursor();
                blur.SetActive(true);
                inventoryCanvas.interactable = true;
                inventoryCanvas.blocksRaycasts = true;
            }
            else
            {
                HUD.alpha = 1f;
                inventoryCanvas.alpha = 0f;
                if(!dialogueEnabled)DisableCursor();
                blur.SetActive(false);
                inventoryCanvas.interactable = false;
                inventoryCanvas.blocksRaycasts = false; 
            }
        }

        public void EnableCursor()
        {
            cameraMovement.enableCursor = true;
            cameraMovement.lockCursor = false;
        }
        public void DisableCursor()
        {
            cameraMovement.enableCursor = false;
            cameraMovement.lockCursor = true;
        }

    }
}
