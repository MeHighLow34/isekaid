using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class Health : MonoBehaviour
    {
        public float health;
        float maxHealth;
        BaseStats stats;
        private void Awake()
        {
           stats = GetComponent<BaseStats>();
           maxHealth = stats.GetStat(Stat.Health);
           health = maxHealth;
        }

        public float GetDecimal()
        {
            return health / maxHealth;
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            if(health <= 0)
            {
                HandleDeath();
            }
        }

        private void HandleDeath()
        {
            print("Dead Boi");
        }
    }
}