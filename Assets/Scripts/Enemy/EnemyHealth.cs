using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Isekai
{
    public class EnemyHealth : MonoBehaviour
    {
       
        public float health;
        float maxHealth;
        BaseStats stats;
        Ragdoll ragdoll;
        public EnemyManager manager;
        [Header("Experience")]
        public Experience experience;
        public float experiencePoints = 10;
        [Header("Effects")]
        public GameObject floatingText;
        public Transform floatingTextSpawnPosition;
        [Header("Post Death Effects")]
        public GameObject canvas;
        [Header("Punk - Specific")]
     //   public GameObject heartExplosionParticle;
        public GameObject hearth;
        private void Awake()
        {
            experience = FindObjectOfType<Experience>();
         

            ragdoll = GetComponent<Ragdoll>();
            manager = GetComponent<EnemyManager>();

            stats = GetComponent<BaseStats>();
            maxHealth = stats.GetStat(Stat.Health);
            health = maxHealth;

            experiencePoints = stats.GetStat(Stat.ExperienceToGive)/3;
        }

        public float GetDecimal()
        {
            return health / maxHealth;
        }

        public void TakeDamage(float damage)
        {
            if(floatingText != null && health > 0)
            {
                ShowFloatingText(damage);
            }
            health -= damage;
            if (health <= 0)
            {
                HandleDeath();
            }
        }
        void ShowFloatingText(float damage)
        {
            var go = Instantiate(floatingText, floatingTextSpawnPosition.position, Quaternion.identity, floatingTextSpawnPosition);
            go.GetComponentInChildren<TextMeshPro>().text = damage.ToString();
        }

        private void HandleDeath()
        {
            experience.GainExp(experiencePoints);
            health = 0;
            ragdoll.disabled = false;
            ragdoll.state = true;
            manager.isDead = true;
            manager.enabled = false;
            canvas.SetActive(false);
            if(hearth != null)
            {
              //  Instantiate(heartExplosionParticle, hearth.transform.position, Quaternion.identity);
                hearth.SetActive(false);
            }
        }
    }
}