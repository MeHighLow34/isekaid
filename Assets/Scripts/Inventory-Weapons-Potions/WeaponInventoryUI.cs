using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class WeaponInventoryUI : MonoBehaviour
    {
        WeaponInventory inventory;
        public Transform weaponsSlotsParent;
        WeaponInventorySlot[] slots;

        private void Start()
        {
            inventory = WeaponInventory.instance;
            inventory.onWeaponChangedCallback += UpdateUI;
            slots = weaponsSlotsParent.GetComponentsInChildren<WeaponInventorySlot>();  
        }


        public void UpdateUI()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if(i < inventory.weapons.Count)
                {
                    slots[i].AddWeapon(inventory.weapons[i]);
                }
                else
                {
                    slots[i].ClearSlot();
                }
            }
        }
    }
}