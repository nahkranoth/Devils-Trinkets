using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hobscure.Items
{
    [CreateAssetMenu(fileName = "Data", menuName = "Hobscure/ItemDataCollection", order = 1)]
    public class ItemDataCollection : ScriptableObject
    {

        public ItemDataWrapper[] itemsData;

        public Item[] items { get { return transmuteItemReferences(itemsData); } }

        private Item[] transmuteItemReferences(Object[] rawData)
        {
            List<Item> return_items = new List<Item>();
            foreach (var item in itemsData)
            {
                return_items.Add(item.itemData);
            }
            return return_items.ToArray();
        }
    }
}