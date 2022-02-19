using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Fiesta
{
    public class FaceCamera : MonoBehaviour
    {
        public Camera camera;

        private void Awake()
        {
            camera = Camera.main;
        }

        private void Update()
        {
            transform.forward = Camera.main.transform.forward;
        }
    }
}
