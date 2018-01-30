using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using Hobscure.Items;
using Zenject;


namespace Hobscure.World
{
    [Serializable]
    public class SaveInventory
    {

        public SaveItem[] items;

        public SaveInventory(List<Item> itemList)
        {

            items = new SaveItem[itemList.Count];
            for (int i = 0; i < itemList.Count; i++)
            {
                var item = new SaveItem(itemList[i]);
                items[i] = item;
            }
        }

        public List<Item> itemsAsList(ItemManager itemManager)
        {

            List<Item> normalItems = new List<Item>();
            for (int i = 0; i < items.Length; i++)
            {
                normalItems.Add(itemManager.GetItemByName(items[i].name));
            }
            return normalItems;
        }
    }
}