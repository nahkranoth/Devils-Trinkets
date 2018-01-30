using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using Hobscure.Main;
using Hobscure.Items;

namespace Hobscure.Player { 
    public class PlaceState : iPlayerState {

        PlayerManager playerManager;

        FirstPersonController playerController;

        GameObject blueprint;
        BlueprintObject blueprintObject;

        Item item;

        private Vector3 gridOffset = new Vector3(0f, 0f, 0f);

        PlayerStateManager stateManager;

        public PlaceState(PlayerStateManager stateManager, Item item)
        {
            this.stateManager = stateManager;
            this.playerManager = stateManager.playerManager;
            this.playerController = stateManager.playerManager.playerController;
            this.item = item;
        }

        public void Init()
        {
            playerController.enabled = true;
            playerController.m_MouseLook.SetCursorLock(true);

            var obj = playerManager.objectManager.GetObjectByName("blueprint");
            blueprint = GameObject.Instantiate(obj);
            blueprintObject = blueprint.GetComponent<BlueprintObject>();
            blueprintObject.SetItem(item, stateManager.objectManager);
        }

        public void Update()
        {

            if (playerManager.GetLookAtDistance() != 0f)
            {
                var distance = Mathf.Max(1f, playerManager.GetLookAtDistance());
                var pos = playerManager.transform.position + (playerManager.transform.rotation * (Vector3.forward * Mathf.Min(3f, distance)));
                blueprint.transform.localPosition = RestrictByGrid(pos);
            }

            if (Input.GetMouseButtonDown(0) && blueprintObject.placeable)
            {
                WorldManager.instance.PlaceMachineObject(blueprint.transform.localPosition, playerManager.transform.rotation.eulerAngles, item);
                playerManager.playerStateManager.SwitchStates(new WalkState(stateManager));
                playerManager.inventory.RemoveItem(item);
            }
        }

        Vector3 RestrictByGrid(Vector3 position)
        {
            return new Vector3(Mathf.Floor(position.x + 0.5f), 1f, Mathf.Floor(position.z + 0.5f)) + gridOffset;
        }

        public void Exit()
        {
            GameObject.Destroy(blueprint);
        }
    }
}