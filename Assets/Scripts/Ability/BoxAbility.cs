using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class BoxAbility : Ability
    {
        [Header("Box Ability Attributes")]
        public Transform playerTransform;
        public GameObject boxPrefab;
        [Header("Position to Instantiate Box")]
        public float yPosition;
        public float zPosition;
        public Camera fpsCam;
        private void Awake()
        {
            fpsCam = Camera.main;   
        }
        private void Start()
        {
            beingUsed = false;
            time = timeLimit;
            canUse = true;
        }
        public override void UseAbility()
        {
            if (canUse == false) return;   // We can't use because timer is still on
            Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 closestThing = hit.transform.position;
                if(Vector3.Distance(playerTransform.position, closestThing) >= 5)
                {
                    print("You can spawn here");
                    Vector3 spawnPosition = playerTransform.position;
                    spawnPosition.y = spawnPosition.y + yPosition;
                    Instantiate(boxPrefab, spawnPosition + playerTransform.forward * zPosition, Quaternion.identity);
                    canUse = false;
                    time = timeLimit;  // Here we used the ability so we start a timer
                }
                else
                {
                    print("Invalid Position");
                }
            }
            else
            {
                Vector3 spawnPosition = playerTransform.position;
                spawnPosition.y = spawnPosition.y + yPosition;
                Instantiate(boxPrefab, spawnPosition + playerTransform.forward * zPosition, Quaternion.identity);
            }
        }

        private void Timer()
        {
            time -= Time.deltaTime;   // Just counts down with time and once it reaches zero we canUse ability again...
            if(time <= 0)
            {
                canUse = true;
                time = 0;
            }
        }

        private void Update()
        {
            if(canUse == false)  // Once we have used the ability we start a timer
            {
                Timer();
            }
        }
    }

    
}