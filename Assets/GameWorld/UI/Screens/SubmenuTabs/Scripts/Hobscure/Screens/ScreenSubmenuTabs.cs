using UnityEngine;
using System.Collections;
using System;
using Zenject;
using Hobscure.UI;
using Kuchen;
using Hobscure.Main;

namespace Hobscure.Screens
{

    public class ScreenSubmenuTabs : MonoBehaviour, iComponent
    {

        [Inject]
        IconButton inventoryButton;

        [Inject]
        IconButton marketButton;

        [Inject]
        IconButton optionsButton;

        [Inject]
        CustomTextField submenuSelectedText;

        [HideInInspector]
        public ScreenSubmenuTabsModel model;

        [SerializeField]
        RectTransform inventoryButtonHolder;

        [SerializeField]
        RectTransform marketButtonHolder;

        [SerializeField]
        RectTransform optionsButtonHolder;

        [SerializeField]
        RectTransform submenuTextHolder;

        [SerializeField]
        IconButtonStyle inventoryButtonStyle;

        [SerializeField]
        IconButtonStyle marketButtonStyle;

        [SerializeField]
        IconButtonStyle optionsButtonStyle;

        [SerializeField]
        CustomTextFieldStyle submenuTabTextStyle;


        void Start()
        {
            inventoryButton.transform.SetParent(inventoryButtonHolder, false);
            inventoryButton.SetStyle(inventoryButtonStyle);
            inventoryButton.SetInteract(false);
            inventoryButton.command = ScreenSubmenuTabsSignals.inventoryButtonClicked;

            marketButton.transform.SetParent(marketButtonHolder, false);
            marketButton.SetStyle(marketButtonStyle);
            marketButton.command = ScreenSubmenuTabsSignals.marketButtonClicked;

            optionsButton.transform.SetParent(optionsButtonHolder, false);
            optionsButton.SetStyle(optionsButtonStyle);
            optionsButton.command = ScreenSubmenuTabsSignals.optionsButtonClicked;

            submenuSelectedText.transform.SetParent(submenuTextHolder, false);
            submenuSelectedText.SetTextStyle(submenuTabTextStyle);
            
            submenuSelectedText.SetText("Inventory");
        }

        void ResetButtons()
        {
            inventoryButton.SetInteract(true);
            marketButton.SetInteract(true);
            optionsButton.SetInteract(true);
        }

        public void setInventoryView()
        {
            ResetButtons();
            submenuSelectedText.SetText("Inventory");
            inventoryButton.SetInteract(false);
        }

        public void setMarketView()
        {
            ResetButtons();
            submenuSelectedText.SetText("Market");
            marketButton.SetInteract(false);
        }

        public void setOptionsView()
        {
            ResetButtons();
            submenuSelectedText.SetText("Options");
            optionsButton.SetInteract(false);
        }

        public void setStateInventory()
        {
            setInventoryView();
            UIStateManager.instance.SwitchStates(new InventoryState(UIStateManager.instance));
        }

        public void setStateMarket()
        {
            setMarketView();
            UIStateManager.instance.SwitchStates(new MarketState(UIStateManager.instance));
        }

        public void setStateOptions()
        {
            setOptionsView();
            UIStateManager.instance.SwitchStates(new GameOptionsState(UIStateManager.instance));
        }

        public void ApplyModel(iComponentModel data)
        {
            model = data as ScreenSubmenuTabsModel;
        }
    }
}