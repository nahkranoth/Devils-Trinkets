using Hobscure.Items;
using Hobscure.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hobscure.Objects;

namespace Hobscure.Screens
{
    [Serializable]
    public class ScreenMachineProcessorModel: iComponentModel, iScreenTransferSubModel
    {
        public ItemContainerModel inputItem;
        public ItemContainerModel outputItem;
        public ObjectInventoryManager selectedWorldObject;

        public ScreenMachineProcessorModel(ObjectInventoryManager worldObject)
        {
            selectedWorldObject = worldObject;
        }

        public void AddContainers(List<Item> items)
        {
            if(items.Count > 2) { Debug.LogError("MachineProcessorModel cannot have more then 2 items at a time"); }

            for (int i = 0; i < items.Count; i++)
            {
                AddToCorrectContainer(items[i]);
            }
        }

        void AddToCorrectContainer(Item item)
        {
            if (selectedWorldObject.itemTypesAbleToReceive.Contains(item.name))
            {
                inputItem = new ItemContainerModel() { item = item };
            }

            if (selectedWorldObject.itemTypesAbleToDispatch.Contains(item.name))
            {
                outputItem = new ItemContainerModel() { item = item };
            }
        }

        public List<Item> GetSelectedAsItems()
        {
            var toTransfer = GetSelectedContainers();
            return toTransfer.Select(i => i.item).ToList();
        }

        public List<ItemContainerModel> GetSelectedContainers()
        {
            var itemContainers = new List<ItemContainerModel>();
            if (inputItem != null && inputItem.selected) itemContainers.Add(inputItem);
            if (outputItem != null && outputItem.selected) itemContainers.Add(outputItem);
            return itemContainers;
        }

        public void MergeWithInventory(List<ItemContainerModel> itemContainers)
        {
            if (itemContainers.Count > 1) { Debug.LogError("MachineProcessorModel cannot have more then 1 item at a time"); }
            inputItem = itemContainers[0];
        }

        public void RemoveSelected()
        {
            if (inputItem != null) inputItem = null;
            if (outputItem != null) outputItem = null;
        }

        public void DeselectAll()
        {
            if(inputItem != null) inputItem.selected = false;
            if(outputItem != null) outputItem.selected = false;
        }

        public bool IsActive()
        {
            bool active = false;

            if (inputItem != null) { active = inputItem.selected; }
            if (outputItem != null) { active = outputItem.selected; }

            return active;
        }
        public List<Item> GetAllItems()
        {
            var items = new List<Item>() { };
            if (inputItem != null) { items.Add(inputItem.item); }
            if (outputItem != null) { items.Add(outputItem.item); }
            return items;
        }
    }
}