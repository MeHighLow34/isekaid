using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Isekai
{
    public class WeaponInventorySlot : MonoBehaviour
    {
        Weapon weapon;
        public Image icon;
        WeaponInfo weaponInfo;

        private void Awake()
        {
            weaponInfo = FindObjectOfType<WeaponInfo>();
        }

        public void AddWeapon(Weapon newWeapon)
        {
            weapon = newWeapon;
            icon.sprite = weapon.icon;
            icon.enabled = true; 
        }

        public void ClearSlot()
        {
            weapon = null;
            icon.sprite = null;
            icon.enabled=false;

        }

        public void Remove()
        {
            WeaponInventory.instance.Remove(weapon);    
        }

        public void Use()
        {
            print("DUDE DISPLAY THIS SHIT" + gameObject.name);
            weaponInfo.Display(weapon);
        }
    }
}
