using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    [CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 1)]
    public class Item : ScriptableObject
    {
        new public string name;
        public Sprite icon = null;
    }
}
