using UnityEngine;
using System.Collections;
using System.Linq;

namespace Hobscure.Items
{
    public class ItemManager
    {
        readonly ItemDataCollection collection;

        public ItemManager(ItemDataCollection collection)
        {
            this.collection = collection;
        }

        public Item GetItemByName(string name)
        {
            if (collection.items.Any(i => i.name == name))
            {
                Item returnItem = collection.items.Single(i => i.name == name);
                return returnItem;
            }else
            {
                Debug.LogError("Item could not be found by item name: " + name);
                return null;
            }
            
        }
    }
}
