using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class WeaponPickUp : Interactable
    {
        public Weapon weapon;

        public override void Interact()
        {
            base.Interact();
            PickUp();
        }

        private void PickUp()
        {
            var hasBeenPickedUp  = WeaponInventory.instance.Add(weapon);
            if (hasBeenPickedUp)
            {
                Destroy(gameObject);
            }
        }

    }
}
