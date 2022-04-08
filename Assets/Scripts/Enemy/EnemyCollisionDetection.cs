using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class EnemyCollisionDetection : MonoBehaviour
    {
        [Header("Dependencies")]
        public BaseStats baseStats;
        public EnemyManager enemyManager;
        [Header("Damage-Properties")]
        public float damage;

        private void Awake()
        {
            damage = baseStats.GetStat(Stat.Damage);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (enemyManager.isDead) return;
            if (enemyManager.Ally == false)
            {
                if (other.gameObject.tag == "Player" && other.gameObject != enemyManager.gameObject)
                {
                    Health playerHealth = other.GetComponentInParent<Health>();
                    playerHealth.TakeDamage(damage);
                }
            }
            else
            {
                if(other.gameObject.tag == "Enemy")
                {
                    EnemyHealth enemyHealth = other.GetComponentInParent<EnemyHealth>();
                    if(enemyHealth == null) enemyHealth = other.GetComponent<EnemyHealth>();
                    if (enemyHealth == null) return;
                    if (enemyHealth == enemyManager.GetComponent<EnemyHealth>()) return;
                    var enemiesManager = enemyHealth.gameObject.GetComponent<EnemyManager>();
                    print(enemiesManager.currentTarget + baseStats.gameObject.name);
                    if(enemiesManager.currentTarget == null || enemiesManager.currentTarget == enemyHealth.GetComponent<BaseStats>())
                    {
                        enemiesManager.currentTarget = baseStats;
                    }
                    enemyHealth.TakeDamage(damage); 
                }
            }
        }
    }
}
