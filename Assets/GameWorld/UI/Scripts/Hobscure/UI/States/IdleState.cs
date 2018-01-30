using UnityEngine;
using System.Collections;
using Hobscure.Screens;
using Zenject;
using Hobscure.Main;
using Hobscure.Player;

namespace Hobscure.UI
{
    public class IdleState : iUIState
    {
        [Inject]
        DiContainer container;

        UIStateManager stateManager;
        InputManager input;

        PlayerManager player;
        
        public IdleState(UIStateManager stateManager)
        {
            this.stateManager = stateManager ;
            this.container = stateManager.container;
            this.input = stateManager.input;
        }

        public void Init()
        {
            player = container.Resolve<PlayerManager>();
            stateManager.CameraHide();
        }

        public void Update()
        {
            if (player.WorldObjectLookingAt() != null && input.GetButtonDown("Fire2"))
            {
                stateManager.SwitchStates(new InventoryTransferState(stateManager));
            }
            else if (player.NPCLookingAt() != null && input.GetButtonDown("Fire2"))
            {
                stateManager.SwitchStates(new NPCInteractionState(stateManager));
            }
            else if (input.GetButtonDown("Menu"))
            {
                stateManager.SwitchStates(new InventoryState(stateManager));
            }
        }

        public void Exit()
        {
            stateManager.CameraHide();
        }
    }
}