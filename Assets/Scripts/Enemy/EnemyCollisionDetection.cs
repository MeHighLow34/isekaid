using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class EnemyCollisionDetection : MonoBehaviour
    {
        [Header("Dependencies")]
        public BaseStats baseStats;
        [Header("Damage-Properties")]
        public float damage;
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                Health playerHealth = other.GetComponentInParent<Health>();
                damage = baseStats.GetStat(Stat.Damage);
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
