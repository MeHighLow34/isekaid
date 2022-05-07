using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class AIConversant : MonoBehaviour
    {
        [SerializeField] Dialogue dialogue;
        [SerializeField] float range = 5f;
        PlayerConversant player;
        private void Awake()
        {
            player = FindObjectOfType<PlayerConversant>();
        }

        private void Update()
        {
           float distance = Vector3.Distance(transform.position, player.gameObject.transform.position); 
           if (distance < range && Input.GetKeyDown(KeyCode.J))
           {
                player.StartDialogue(dialogue);
           }
        }
    }
}