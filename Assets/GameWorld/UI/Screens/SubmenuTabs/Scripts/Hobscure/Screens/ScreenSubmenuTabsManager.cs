using UnityEngine;
using System.Collections;
using System;
using Zenject;
using Kuchen;

namespace Hobscure.Screens
{
    public class ScreenSubmenuTabsManager : IScreenManager
    {

        [Inject]
        ScreenSubmenuTabs view;

        public void ConstructViewModel()
        {
            var model = new ScreenSubmenuTabsModel();
            view.ApplyModel(model);
        }

        public void setInventoryView()
        {
            view.setInventoryView();
        }

        public void Show()
        {
            view.gameObject.SetActive(true);
            view.Subscribe(ScreenSubmenuTabsSignals.inventoryButtonClicked, () => { view.setStateInventory(); });
            view.Subscribe(ScreenSubmenuTabsSignals.marketButtonClicked, () => { view.setStateMarket(); });
            view.Subscribe(ScreenSubmenuTabsSignals.optionsButtonClicked, () => { view.setStateOptions(); });
        }

        public void Close()
        {
            view.Unsubscribe(ScreenSubmenuTabsSignals.inventoryButtonClicked);
            view.Unsubscribe(ScreenSubmenuTabsSignals.marketButtonClicked);
            view.Unsubscribe(ScreenSubmenuTabsSignals.optionsButtonClicked);
            view.gameObject.SetActive(false);
        }
    }
}
