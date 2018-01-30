using UnityEngine;
using System.Collections;
using Zenject;
using Hobscure.Screens;
using Hobscure.Main;
using Hobscure.Player;

namespace Hobscure.UI { 
    public class InventoryState : iUIState
    {

        DiContainer container;
        UIStateManager stateManager;
        InputManager input;
        PlayerManager player;
        ScreenPlayerInventoryManager screenManager;

        public InventoryState(UIStateManager stateManager)
        {
            this.stateManager = stateManager;
            this.container = stateManager.container;
            this.input = stateManager.input;
            this.player = stateManager.player;
        }

        public void Init()
        {
            stateManager.CameraShow();
            screenManager = container.Resolve<ScreenPlayerInventoryManager>();
            screenManager.ConstructViewModel();
            screenManager.Show();
            stateManager.ShowScreenSubMenuTabs();
            stateManager.screenSubmenuTabsManager.setInventoryView();//set submenu to Inventory View
        }

        public void Update()
        {
            if (input.GetButtonDown("Menu") || input.GetButtonDown("Cancel") || input.GetButtonDown("Fire2"))
            {
                stateManager.SwitchStates(new IdleState(stateManager));
                player.playerStateManager.SwitchStates(new WalkState(player.playerStateManager));
            }
        }

        public void Exit()
        {
            stateManager.HideScreenSubMenuTabs();
            stateManager.CameraHide();
            screenManager.Close();
           
        }
    }
}