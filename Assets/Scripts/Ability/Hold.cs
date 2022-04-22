using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class Hold : Ability
    {
        [Header("Ability Stats")]
        public Transform holdParent;
        public float holdRange = 5;
        public float moveForce = 250;
        GameObject heldObj;
        public Transform cameraTransform;
       // public bool beingUsed;
        public float shootPower;
        AbilityManager abilityManager;
        private void Awake()
        {
            abilityManager = FindObjectOfType<AbilityManager>();
            abilityIntermediary = FindObjectOfType<AbilityIntermediary>();
            animationManager = FindObjectOfType<AnimationManager>();
        }

        public override void UseAbility()
        {
            beingUsed = !beingUsed;  // Here we are turning ability on and off
        }
        private void FixedUpdate()
        {
            if(abilityManager.abilitiesDisabled == true)
            {
                beingUsed = false;
                return;
            }
            if (beingUsed)  
            {
                if (heldObj == null)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward), out hit, holdRange))
                    {
                        if (hit.transform.gameObject.tag == "Throwable")
                        {
                            HoldObject(hit.transform.gameObject);
                        }
                        else
                        {
                            print("Cannot Throw that Object");         
                            return;
                        }
                    }
                    else
                    {
                        beingUsed = false;  // If we don't find any object to hold...we can change to the next ability
                    }
                }
            }
            if(beingUsed == false && heldObj != null) // Once we press R again and cancel ability we drop the object...
            {
                DropObject();
            }

            if (heldObj != null)
            {
                if (Input.GetKey(KeyCode.T))
                {
                    print("Throwing Object");
                    ThrowObject();
                }
                else
                {
                    MoveObject();
                }
            }
        }
        private void DropObject()
        {
            Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
            heldRig.useGravity = true;
            heldRig.drag = 1;

            heldObj.transform.parent = null;
            heldObj = null;
            beingUsed = false;
            animationManager.animator.SetBool("Holding", false);
        }
        private void MoveObject()
        {
            if(Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
            {
                Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
                heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
            }
        }

        private void ThrowObject()
        {
         //   animationManager.animator.SetBool("Holding", false);
            Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
            heldRig.useGravity = true;
            heldRig.drag = 1;


            heldRig.AddForce(cameraTransform.TransformDirection(Vector3.forward) * shootPower, ForceMode.Impulse);
            heldObj.transform.parent = null;
            heldObj = null;
            beingUsed = false;
            animationManager.animator.SetBool("Throw", true);
            abilityManager.StartTimer(10f);
        }
        void HoldObject(GameObject holdObject)
        {
            if(holdObject.GetComponent<Rigidbody>() != null)
            {
                Rigidbody objRig = holdObject.GetComponent<Rigidbody>();
                objRig.useGravity = false;
                objRig.drag = 10;
              //  objRig.velocity = Vector3.zero;
                objRig.freezeRotation = true;
                objRig.transform.parent = holdParent;
                heldObj = holdObject;
                animationManager.animator.SetBool("Holding", true);

            }
        }
    }
}
