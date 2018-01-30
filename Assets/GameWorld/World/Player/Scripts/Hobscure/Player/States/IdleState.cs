using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using Hobscure.Main;

namespace Hobscure.Player { 
    public class IdleState : iPlayerState, iPlayerGlobalState {

        FirstPersonController playerController;

        //As a global state the state is switchable to from any location
        public bool active { get; set; }

        public IdleState(PlayerStateManager manager)
        {
            this.playerController = manager.playerManager.playerController;
        }

        public void Init()
        {
            active = true;
            playerController.enabled = false;
            playerController.m_MouseLook.SetCursorLock(false);
        }

        public void Update()
        {
       
        }

        public void Exit()
        {
            active = false;
            Debug.Log("Exit Idle");
        }
    }
}
