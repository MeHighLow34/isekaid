using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Isekai
{
    public class Projectile : MonoBehaviour
    {
        [Header("Assignables")]
        public Rigidbody rb;
        public GameObject explosion;
        public LayerMask enemyLayer;
        [Header("Stats")]
        [Range(0f, 1f)]
        public float bounciness;
        public bool useGravity;
        [Header("Damage")]
        public int explosionDamage;
        public float explosionRange;
        public float explosionForce;
        [Header("Lifetime")]
        public int maxCollisions;
        public float maxLifetime;
        public bool explodeOnTouch = true;
        
        int collisions;
        PhysicMaterial physicMaterial;


        public bool hitPlayer;
        public bool enemyBullet;
        private void Start()
        {

            Setup();
        }

        private void Update()
        {
            if (collisions >= maxCollisions)
            {
                Explode();
                return;
            }
            maxLifetime -= Time.deltaTime;
            if(maxLifetime <= 0f)
            {
                Explode();
            }
            
        }
        private void Explode()
        {
          
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
            }
            Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, enemyLayer);
            for (int i = 0; i < enemies.Length; i++)
            {
                // here we will get enemyHealth and they will take Damage obviously and setting up progression and all the levels will be easy peasy lemon squezzyyy
                EnemyHealth enemy = enemies[i].GetComponent<EnemyHealth>();
                if(enemy != null)
                {
                    if (enemy == this) return;
                    enemy.TakeDamage(explosionDamage);
                }
                
            }
            Collider[] objects = Physics.OverlapSphere(transform.position, explosionRange);
            for (int i = 0;i < objects.Length; i++)
            {
                if (enemyBullet)
                {
                    var player = objects[i].GetComponent<Health>();
                    if (player != null)
                    {
                        print(player.name); 
                        player.TakeDamage(explosionDamage);
                    }
                }
                var newObject = objects[i].GetComponent<Rigidbody>();
                if(newObject != null)
                {
                    if (newObject.GetComponent<EnemyManager>() != null) return; // we don't add force to the enemy
                    newObject.AddExplosionForce(explosionForce, transform.position, explosionRange);
                }
            }
            Destroy(gameObject);
        }
        private void Delay()
        {
            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            collisions++;
            //Explode if bullet hits an enemy and explodeOnTouch is activated
            if(collision.collider.CompareTag("Enemy") && explodeOnTouch)
            {
                Explode();
            }

        }
        private void Setup()
        {
            hitPlayer = false;
            physicMaterial = new PhysicMaterial();
            physicMaterial.bounciness = bounciness;
            physicMaterial.frictionCombine = PhysicMaterialCombine.Minimum;
            physicMaterial.bounceCombine = PhysicMaterialCombine.Maximum;
            GetComponent<SphereCollider>().material = physicMaterial;
            rb.useGravity = useGravity;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, explosionRange);
        }
    }
}
