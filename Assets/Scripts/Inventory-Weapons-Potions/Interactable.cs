using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class Interactable : MonoBehaviour
    {
        public float radius = 3f;


        public virtual void Interact()
        {
            print("Interacting with " + gameObject.name);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;   
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}