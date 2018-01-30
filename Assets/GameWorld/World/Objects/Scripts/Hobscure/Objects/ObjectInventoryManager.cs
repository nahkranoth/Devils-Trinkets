using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Zenject;
using Hobscure.Items;
using Hobscure.Player;
using Hobscure.Screens;

namespace Hobscure.Objects { 

    //A World Object is an interactible Object with an inventory. Thats it, don't specify more then that

    public class ObjectInventoryManager : MonoBehaviour {

        public ObjectInventoryModel inventory = new ObjectInventoryModel();

        [Inject]
        ItemManager itemManager;

        [Inject]
        ScreenInventoryTransfer inventoryTransferScreen;

        public int containLimit;

        [SerializeField]
        //TODO: Change to ItemDataWrapper array instead of strings
        //ID names of the items this inventory can receive
        public string[] itemTypesAbleToReceive;

        [SerializeField]
        //ID names of the items this inventory can dispatch
        public string[] itemTypesAbleToDispatch;

        public bool CanReceive(Item item)
        {
            //has space and is able to receive this particulair item, or has no restriction on what item to receive
            return HasStorageSpace(1) && (itemTypesAbleToReceive.Contains(item.name) || (itemTypesAbleToReceive.Length == 0));
        }

        //multiple overload
        public bool CanReceive(List<Item> items)
        {
            return HasStorageSpace(items.Count) && ((MayContainItemTypes(items) || (itemTypesAbleToReceive.Length == 0)));
        }
        
        //is not yet filled up to containLimit
        private bool HasStorageSpace(int amount)
        {
            return (inventory.itemCollection.Count + amount <= containLimit || containLimit == 0);
        }


        private bool MayContainItemTypes(List<Item> items)
        {
            //Except will give you all of the items in listA that are not in listB
            //compares the two lists and if there are left-overs it will return false
            List<string> itemNames = items.Select(i => i.name).ToList();
            return itemNames.Except(itemTypesAbleToReceive).ToArray().Length == 0;
        }

        public void AddItem(Item item)
        {
            inventory.itemCollection.Add(item);
            inventoryTransferScreen.manager.ConstructViewModel();
        }

        public Item DispatchItem()
        {
            //Get first from suitable items
            var suitableItems = GetSuitableDispatchableItems();
            if(suitableItems.Count > 0) { 
                var itemToGrab = suitableItems.First();
                inventory.itemCollection.Remove(itemToGrab);
                inventoryTransferScreen.manager.ConstructViewModel();
                return itemToGrab;
            }
            return null;
        }

        private List<Item> GetSuitableDispatchableItems()
        {
            List<Item> items = new List<Item>();
            if (itemTypesAbleToDispatch.Count() != 0) {
                List<string> itemNames = inventory.itemCollection.Select(i => i.name).ToList();
                List<string> existingItems = itemTypesAbleToDispatch.Intersect(itemNames).ToList();

                for (int i = 0; i < existingItems.Count(); i++)
                {
                    Debug.Log("Can Dispatch: " + existingItems[i]);
                    items.Add( inventory.itemCollection.Find(x => x.name == existingItems[i]) );
                }
            }else
            {
                Debug.Log("No restrictions: Dispatch all items ");
                items = inventory.itemCollection;
            }

            return items;
        }

        public void LoadInventory(List<Item> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                var savedItem = items[i];
                inventory.itemCollection.Add(savedItem);
            }

        }
        //Saving and loading anchors here

    }
}