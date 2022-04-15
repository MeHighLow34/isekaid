using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Create a New Weapon", order = 1)]
    public class Weapon : ScriptableObject
    {
        public string weaponName;
        public Sprite icon;
        [TextArea]
        public string weaponDescription;
        public GameObject weaponPrefab;
        public GameObject weaponPickUp;



        public void Use()
        {
            Debug.Log("Equip Current Weapon and Put the Old one in the inventory");
        }
    }
}
