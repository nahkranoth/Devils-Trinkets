using UnityEngine;
using System.Collections;
using System;
using Hobscure.Player;
using Zenject;

namespace Hobscure.Screens
{
    public class ScreenHeaderManager : IScreenManager
    {
        [Inject]
        PlayerInventoryManager playerInventory;

        [Inject]
        ScreenHeader view;

        public void ConstructViewModel()
        {
            var model = new ScreenPlayerInventoryModel(playerInventory.model.maxInventoryContainAmount);
            model.cashAmount = playerInventory.GetCashAmount();
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
