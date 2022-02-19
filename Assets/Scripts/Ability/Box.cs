using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Fiesta
{
    public class Box : MonoBehaviour
    {
        public Transform playerTransform;
        Vector3 startPosition;
        Vector3 targetPosition;
        public float timeToReach;
        float t;
        bool stay;
        private void Awake()
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            targetPosition = playerTransform.position;
        }
        private void Start()
        {
            startPosition = transform.position;
            transform.LookAt(targetPosition);
        }

        private void Update()
        {
            if (stay) return;
            t += Time.deltaTime / timeToReach;
           // transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            // transform.position = Vector3.MoveTowards(startPosition, targetPosition, Time.deltaTime * 3);
            transform.Rotate(Vector3.up * (1 * Time.deltaTime));
            if(Vector3.Distance(transform.position, targetPosition) <= 4)
            {
                stay = true;
            }
            Invoke("Delay", 0.1f);
        }

        private void Delay()
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
