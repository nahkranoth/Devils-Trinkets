using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;
using Zenject;
using Kuchen;
using Hobscure.Objects;
using Hobscure.Items;
using Hobscure.Screens;

namespace Hobscure.Player
{
    public class SelectRouteState : iPlayerState
    {

        PlayerManager playerManager;

        InputManager input;

        FirstPersonController playerController;

        PlayerStateManager stateManager;

        public SelectRouteState(PlayerStateManager stateManager)
        {
            this.stateManager = stateManager;
            this.playerManager = stateManager.playerManager;
            this.input = stateManager.input;
            this.playerController = stateManager.playerManager.playerController;
        }

        public void Init()
        {
            playerController.enabled = true;
            playerController.m_MouseLook.SetCursorLock(true);
        }

        public void Update()
        {
            if (input.GetButtonDown("Menu"))
            {
                playerManager.playerStateManager.SwitchStates(new WalkState(stateManager));
            }

            if (Input.GetMouseButtonDown(0) && playerManager.WorldObjectLookingAt() != null)
            {
                Publisher.Publish(ScreenNPCInteractionSignals.doneRoute, playerManager.WorldObjectLookingAt());
                playerManager.playerStateManager.SwitchStates(new IdleState(stateManager));
            }
        }

        public void Exit()
        {
            Debug.Log("Exit Route State");
        }

    }
}
