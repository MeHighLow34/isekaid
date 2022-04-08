using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class Inventory : MonoBehaviour
    {
        #region Singleton
        public static Inventory instance;

        private void Awake()
        {
            if(instance != null)
            {
                Debug.LogWarning("More than one instance of Inventory");
            }
            instance = this;
        }

        #endregion
        public delegate void OnItemChanged();
        public OnItemChanged onItemChangedCallback;
        public int space = 20;
        public List<Item> items  = new List<Item>();

        public bool Add(Item item)
        {
            if (items.Count >= space)
            {
                print("Inventory is FULL");
                return false;
            }
            items.Add(item);
            if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
            return true;
        }

        public void Remove(Item item)
        {
            items.Remove(item);
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
    }
}
