using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System;
using System.Collections;
using Zenject;
using Hobscure.Items;
using Hobscure.Objects;
using Hobscure.NPC;
using Hobscure.Screens;

namespace Hobscure.Player { 
    public class PlayerManager : MonoBehaviour {

        [Inject]
        DiContainer container;

        [Inject]
        public PlayerInventoryManager inventory;

        [Inject]
        ItemManager itemManager;

        [Inject]
        ScreenHeaderManager screenHeaderManager;

        [Inject]
        PlayerSettingsManager playerSettings;

        [Inject]
        InputManager input;

        [Inject]
        public ObjectManager objectManager;

        public Camera playerCamera;

        public int maxInventoryContainAmount;

        public FirstPersonController playerController;

        public PlayerStateManager playerStateManager;

        GameObject lookAt;

        void Start ()
        {
            playerStateManager.SwitchStates(new WalkState(playerStateManager));
            inventory.model.money = playerSettings.GetStartBudget();
            inventory.model.maxInventoryContainAmount = maxInventoryContainAmount;
            screenHeaderManager.ConstructViewModel(); //Update Header
        }

        void Update()
        {
            lookAt = GetLookatObject();

            //Fell in lava
            if(transform.position.y < -10)
            {
                //reset position
                transform.localPosition = new Vector3(0, 25f, 0f);
            }
        }

        public void PlaceItem(Item item)
        {
            playerStateManager.SwitchStates(new PlaceState(playerStateManager, item));
        }

        public void SelectObject()
        {
            playerStateManager.SwitchStates(new SelectRouteState(playerStateManager));
        }

        RaycastHit hit;

        public RaycastHitter RayCastLookAt()
        {
            var cameraCenter = playerCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, playerCamera.nearClipPlane));
            if (Physics.Raycast(cameraCenter, playerCamera.transform.forward, out hit, 1000))
            {
                return new RaycastHitter { obj = hit.transform.gameObject, distance = hit.distance };
            }
            else
            {
                return null;
            }
        }

        public GameObject GetLookatObject()
        {
            if (RayCastLookAt() != null)
            {
                return RayCastLookAt().obj;
            }
            return null;
        }

        public float GetLookAtDistance()
        {
            if (RayCastLookAt() != null)
            {
                return RayCastLookAt().distance;
            }
            return 0f;
        }

        public ObjectInventoryManager WorldObjectLookingAt()
        {
            if (lookAt != null) { 
                return lookAt.GetComponent<ObjectInventoryManager>();
            }
            return null;
        }

        public NPCManager NPCLookingAt()
        {
            if (lookAt != null)
            {
                return lookAt.GetComponent<NPCManager>();
            }
            return null;
        }

    }
}