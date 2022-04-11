using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Isekai
{
    public class WeaponInfo : MonoBehaviour
    {
        public Weapon currentWeapon;
        public WeaponManager weaponManager;
        public Image icon;
        public TextMeshProUGUI title;
        public TextMeshProUGUI description;

        private void Awake()
        {
            weaponManager = FindObjectOfType<WeaponManager>();
        }
        public void Display(Weapon weapon)
        {
            currentWeapon = weapon;
            icon.sprite = weapon.icon;  
            title.text = weapon.name;
            description.text = weapon.weaponDescription;
        }

        public void Use()
        {
            weaponManager.EquipWeapon(currentWeapon);
        }


    }
}