using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class Hypnotize : Ability
    {
        Camera fpsCam;
        AbilityManager abilityManager;
        private void Awake()
        {
            abilityManager = FindObjectOfType<AbilityManager>();
            fpsCam = Camera.main;   
        }
        public override void UseAbility()
        {
            if(abilityManager.abilitiesDisabled == true)
            {
                return;
            }
            Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                EnemyManager enemy = hit.transform.gameObject.GetComponentInParent<EnemyManager>();
                if(enemy != null)
                {
                    enemy.Ally = true;
                    enemy.currentTarget = null;
                    enemy.FindANewTarget();
                }
            }
        }
    }
}