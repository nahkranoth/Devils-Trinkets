using UnityEngine;
using System.Collections;
using Hobscure.Screens;
using Zenject;
using Hobscure.Main;
using Hobscure.Player;

namespace Hobscure.UI { 
    public class InventoryTransferState : iUIState
    {

        DiContainer container;
        UIStateManager stateManager;
        InputManager input;
        PlayerManager player;
        ScreenInventoryTransferManager screenManager;

        public InventoryTransferState(UIStateManager stateManager)
        {
            this.stateManager = stateManager;
            this.container = stateManager.container;
            this.input = stateManager.input;
            this.player = stateManager.player;
        }

        public void Init()
        {
            stateManager.CameraShow();
            screenManager = container.Resolve<ScreenInventoryTransferManager>();
            screenManager.ConstructViewModel();
            screenManager.Show();
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
            stateManager.CameraHide();
            screenManager.Close();
            Debug.Log("Exit Inventory");
        }
    }
}