using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class EnemyHealth : MonoBehaviour
    {
        public float health;
        float maxHealth;
        BaseStats stats;
        Ragdoll ragdoll;
        EnemyManager manager;
        public GameObject canvas;
        private void Awake()
        {

            ragdoll = GetComponent<Ragdoll>();
            manager = GetComponent<EnemyManager>();

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
            if (health <= 0)
            {
                HandleDeath();
            }
        }

        private void HandleDeath()
        {
            health = 0;
            ragdoll.disabled = false;
            ragdoll.state = true;
            manager.isDead = true;
            manager.enabled = false;
            canvas.SetActive(false);
        }
    }
}