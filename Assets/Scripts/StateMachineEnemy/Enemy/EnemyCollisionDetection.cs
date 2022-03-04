using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class EnemyCollisionDetection : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                print(other.gameObject.name + "DA BABY");
                Health playerHealth = other.GetComponentInParent<Health>();
                playerHealth.TakeDamage(3);
            }
        }
    }
}
