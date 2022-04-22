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
        public override void UseAbility()
        {
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
    }
}