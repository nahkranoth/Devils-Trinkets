using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Zenject;
using Hobscure.Player;
using Hobscure.UI;
using Hobscure.Items;

namespace Hobscure.Screens
{
    public class ScreenPlayerInventoryManager : IScreenManager
    {
        [Inject]
        PlayerInventoryManager playerInventory;

        [Inject]
        ScreenPlayerInventory view;

        public void ConstructViewModel()
        {
            var model = new ScreenPlayerInventoryModel(playerInventory.model.maxInventoryContainAmount);
            model.cashAmount = playerInventory.GetCashAmount();

            for (int i = 0; i < playerInventory.model.itemCollection.Count; i++){
                model.localInventoryScroll.gridItems.Add(new ItemContainerModel() { item = playerInventory.model.itemCollection[i] });
            }

            view.ApplyModel(model);
        }

        public void Show()
        {
            view.gameObject.SetActive(true);
        }

        public void Close()
        {
            view.gameObject.SetActive(false);
        }

    }
}