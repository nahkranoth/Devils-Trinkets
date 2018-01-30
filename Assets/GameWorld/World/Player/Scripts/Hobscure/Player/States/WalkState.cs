using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using Hobscure.Objects;

namespace Hobscure.Player { 
    public class WalkState : iPlayerState {

        PlayerStateManager stateManager;

        GameObject lookingAt;

        public WalkState(PlayerStateManager stateManager)
        {
            this.stateManager = stateManager;
        }

        public void Init()
        {
            stateManager.playerManager.playerController.enabled = true;
            stateManager.playerManager.playerController.m_MouseLook.SetCursorLock(true);
        }

        public void Update()
        {
        }

        public void Exit()
        {
            Debug.Log("Exit Walkstate");
        }
    }
}