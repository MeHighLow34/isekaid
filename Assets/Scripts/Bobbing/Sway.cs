using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fiesta
{
    public class Sway : MonoBehaviour
    {
        public float amount;
        public float maxAmount;
        public float smoothAmount;



        public Vector3 initialPosition;

        public float x;
        public float y;


        private void Start()
        {
            initialPosition = transform.localPosition;
        }
        private void Update()
        {
            x = Input.GetAxis("Mouse X");
            y = Input.GetAxis("Mouse Y");

            float moveX = Mathf.Clamp(x * amount, -maxAmount, maxAmount);
            float moveY = Mathf.Clamp(y * amount, -maxAmount, maxAmount);

            Vector3 finalPosition = new Vector3(moveX, moveY, 0);

            transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + initialPosition, Time.deltaTime * smoothAmount); 
        }

   


       
    }
}
