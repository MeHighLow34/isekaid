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
        public Image removeButtonIcon;
        public Button removeButton;
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
            removeButton.interactable = true;
            removeButtonIcon.enabled = true;    
        }

        public void ClearSlot()
        {
            weapon = null;
            icon.sprite = null;
            icon.enabled=false;
            removeButtonIcon.enabled=false;
            removeButton.interactable=false;
        }

        public void Remove()
        {
            WeaponInventory.instance.Remove(weapon);    
        }

        public void Use()
        {
            weaponInfo.Display(weapon);
        }
    }
}
