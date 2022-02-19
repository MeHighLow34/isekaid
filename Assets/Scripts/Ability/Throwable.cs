using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Isekai
{
    public class Throwable : MonoBehaviour  // This goes on to  object we want the Telekenesis ability  to hold
    {
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Enemy")
            {

             //   collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(6f);
            }
        }
    }
}
