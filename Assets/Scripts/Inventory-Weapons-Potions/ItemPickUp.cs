using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Isekai
{
    public class ItemPickUp : Interactable
    {
        public Item item;

        public override void Interact()
        {
            base.Interact();
            PickUp();
        }

        void PickUp()
        {
          var hasBeenPickedUp = Inventory.instance.Add(item);
          if(hasBeenPickedUp)
          {
                Destroy(gameObject);
          }
        }
    }
}
