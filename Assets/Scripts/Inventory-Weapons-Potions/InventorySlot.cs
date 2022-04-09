using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Isekai
{
    public class InventorySlot : MonoBehaviour
    {
        public Button removeButton;
        Item item;
        public Image icon;
        public Image removeButtonIcon;
        public void AddItem(Item newItem)
        {
            item = newItem;
            icon.sprite = item.icon;
            icon.enabled = true;
            removeButton.interactable = true;
            removeButtonIcon.enabled = true;
        }

        public void ClearSlot()
        {
            item = null;
            icon.sprite = null;
            icon.enabled = false;
            removeButton.interactable = false;
            removeButtonIcon.enabled= false;    
        }


        public void OnRemoveButton()
        {
            Inventory.instance.Remove(item);
        }

        public void UseItem()
        {
            if(item != null)
            {
                item.Use(); 
            }
        }
    }
}
