using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class WeaponManager : MonoBehaviour
    {
        public Weapon testWeapon;
        public Weapon currentWeapon;
        public Transform handTransform;
        WeaponInventory weaponInventory;
        private void Awake()
        {
            weaponInventory = GetComponent<WeaponInventory>();
        }
        private void Start()
        {
            EquipWeapon(testWeapon);
        }
        public void EquipWeapon(Weapon newWeapon)
        {
            if(currentWeapon != null)
            {
                UnequipWeapon();
            }
            currentWeapon = newWeapon;
            Instantiate(currentWeapon.weaponPrefab, handTransform);
            weaponInventory.Remove(currentWeapon);
        }

        public void UnequipWeapon()
        {
            weaponInventory.Add(currentWeapon);
            currentWeapon = null;
            GameObject weaponToDestroy = CheckRightHand();
            if(weaponToDestroy != null)
            {
                Destroy(weaponToDestroy);   
            }
        }
        
        private GameObject CheckRightHand()
        {
            var weaponToReturn = handTransform.GetChild(0).gameObject;
            if (weaponToReturn == null)
            {
                return null;
            }
            else
            {
                return weaponToReturn;
            }
        }
    }
}