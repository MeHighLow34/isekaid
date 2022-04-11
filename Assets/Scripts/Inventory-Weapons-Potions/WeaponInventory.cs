using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class WeaponInventory : MonoBehaviour
    {
       
        public static WeaponInventory instance;
        public int space;
        public List<Weapon> weapons = new List<Weapon>();
        private void Awake()
        {
            instance = this;
        }

        
        public delegate void onWeaponChanged();
        public event onWeaponChanged onWeaponChangedCallback;

        public bool Add(Weapon weapon)
        {
            if(weapons.Count >= space)
            {
                Debug.Log("Out of space for weapons");
                return false;
            }
            weapons.Add(weapon);
            onWeaponChangedCallback.Invoke();
            return true;
        }

        public void Remove(Weapon weapon)
        {
            weapons.Remove(weapon);
            onWeaponChangedCallback.Invoke();
        }
    }
}
