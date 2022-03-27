using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class Turret : MonoBehaviour
    {
        [Header("Properties")]
        public float range = 10f;
        public float rotationSpeed = 5f;
        float maxHealth;
        public float health;
        public float recoilTime;
        public float timeBetweenAttacks;
        [Header("Technicalities")]
        public Transform headOfTurret;
        public List<Transform> enemies;
        public Transform currentEnemy;
        public Transform bulletSpawnPoint;
        public GameObject projectile;
        private void Awake()
        {
            health = maxHealth;
            timeBetweenAttacks = 0f;
        }
        private void Update()
        {
            if (currentEnemy == null)
            {
                CheckForEnemy();          // If we have no enemy we are looking for it
                timeBetweenAttacks = 0f;
            }
            if (currentEnemy != null)   // Once we found the enemy in our range and got the closest one
            {
                enemies.Clear();  // Clear the old enemies because new ones are coming
                // Here we could add code so that turret attacks the one that's attacking it but oh well
                if(EnemyIsOutOfRange())    // Once the enemy we are locked on is out of range we set it to null and Look for another again
                {
                    currentEnemy = null;
                }
                if(currentEnemy.GetComponent<EnemyManager>().isDead == true)  // If the enemy we are targeting is dead then we look for enemy again
                {
                    currentEnemy = null;
                }
                LookAtEnemy(currentEnemy);  // Rotate towards enemy...not on y axis...  
                Attack();
            }
        }

        private void Attack()
        {
            timeBetweenAttacks -= Time.deltaTime;
            if(timeBetweenAttacks <= 0f)
            {
                timeBetweenAttacks = recoilTime;
                var projectil = Instantiate(projectile, bulletSpawnPoint.position, Quaternion.identity);
                projectil.GetComponent<TurretProjectile>().target = currentEnemy;
            }
        }

       
        private void LookAtEnemy(Transform closestEnemy)
        {
            Vector3 direction = closestEnemy.position - headOfTurret.position;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            headOfTurret.rotation = Quaternion.Slerp(headOfTurret.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }

        private bool EnemyIsOutOfRange()
        {
            float distance = Vector3.Distance(currentEnemy.position, transform.position);
            if (distance > range)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void CheckForEnemy()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, range);
            for (int i = 0; i < colliders.Length; i++)
            {
                EnemyHealth enemy = colliders[i].GetComponent<EnemyHealth>();
                if(enemy != null && enemy.GetComponent<EnemyManager>().isDead == false)  // if it's in range and if it's not dead then we add it to the enemy list
                {
                    enemies.Add(enemy.transform); 
                }
                if(enemies != null)
                {
                   currentEnemy = GetClosestEnemy(enemies);
                }
            }
        }

        private Transform GetClosestEnemy(List<Transform> enemies)
        {
            Transform tMin = null;
            float minDist = Mathf.Infinity;
            Vector3 currentPos = transform.position;    
            foreach (Transform t in enemies)
            {
                float dist = Vector3.Distance(t.position, currentPos);
                if(dist < minDist)
                {
                    tMin = t;
                    minDist = dist;
                }
            }
            return tMin;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}
