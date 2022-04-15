using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Isekai
{
    public class PlayerPicker : MonoBehaviour
    {
        Camera mainCamera;
        RaycastHit hit;
        public float sphereCastRadius = 0.5f;
        public LayerMask ignoreMe;
        PickUpInfo pickUpInfo;
        private void Awake()
        {
            mainCamera = Camera.main;
            pickUpInfo = FindObjectOfType<PickUpInfo>();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.J))
            {
                Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2f, 0f));
                if(Physics.SphereCast(ray, sphereCastRadius,out hit, ~ignoreMe))
                {
                    Interactable interactable = hit.transform.gameObject.GetComponent<Interactable>();
                    if(interactable != null)
                    {
                        pickUpInfo.DisplayPickUp(interactable.name);
                        interactable.Interact();
                    }
                }
            }
        }
    }
}
