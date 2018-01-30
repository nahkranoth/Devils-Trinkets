using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using Hobscure.Items;
using Hobscure.Screens;

namespace Hobscure.UI
{
    [Serializable]
    public class ScrollListModel: iComponentModel, iScreenTransferSubModel
    {
        public int maxContainAmount { get; private set; }

        public List<ItemContainerModel> gridItems = new List<ItemContainerModel>();

        public ScrollListModel(int _maxContainAmount)
        {
            maxContainAmount = _maxContainAmount;
        }

        public void AddContainers(List<Item> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                gridItems.Add(new ItemContainerModel() { item = items[i] });
            }
        }

        public void RemoveSelected()
        {
            gridItems = gridItems.Where(p => p.selected == false).ToList();
        }

        public List<ItemContainerModel> GetSelectedContainers()
        {
            return gridItems.Where(p => p.selected == true).ToList();
        }

        public List<Item> GetSelectedAsItems()
        {
            var toTransfer = GetSelectedContainers();
            return toTransfer.Select(i => i.item).ToList();
        }

        public void MergeWithInventory(List<ItemContainerModel> itemContainers)
        {
            gridItems = gridItems.Concat(itemContainers).ToList();
        }

        public void DeselectAll()
        {
            gridItems.ToList().ForEach(c => c.selected = false);
        }

        public bool IsActive()
        {
            return gridItems.Any(p => p.selected == true);
        }

        public List<Item> GetAllItems()
        {
            return gridItems.Select(i => i.item).ToList();
        }
    }
}