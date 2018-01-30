using UnityEngine;
using System.Collections;
using Zenject;
using Hobscure.Screens;
using Hobscure.UI;
using Hobscure.Player;

namespace Hobscure.Main { 
    public class UIStateManager : MonoBehaviour {

        public static UIStateManager instance = null;

        [Inject]
        public DiContainer container;

        [Inject]
        public InputManager input;

        [Inject]
        public PlayerManager player;

        [Inject]
        public ScreenSubmenuTabsManager screenSubmenuTabsManager;

        public GameObject inventoryHolder;
        public Camera UICamera;
        public int activeCameraDepth;
        public iUIState state;

        public void ShowScreenSubMenuTabs()
        {
            screenSubmenuTabsManager.ConstructViewModel();
            screenSubmenuTabsManager.Show();
        }

        public void HideScreenSubMenuTabs()
        {
            screenSubmenuTabsManager.Close();
        }

        void Awake () {

            if (instance == null)
            {
                instance = this;
            }else if (instance != this)
            {
                Destroy(gameObject);
            }
            SwitchToIdle();
        }

        public void SwitchToIdle()
        {
            SwitchStates(new UI.IdleState(this));
        }

        public void CameraShow()
        {
            UICamera.depth = activeCameraDepth;
        }

        void Update()
        {
            state.Update();
        }

        public void CameraHide()
        {
            UICamera.depth = -1;
        }

        public void SwitchStates(iUIState state)
        {
            if(this.state != null)
            {
                this.state.Exit();
            }
            this.state = state;
            this.state.Init();
            
        }

    }
}