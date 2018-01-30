using UnityEngine;
using System.Collections.Generic;
using Zenject;
using Hobscure.Player;
using Hobscure.World;
using Hobscure.Items;
using Hobscure.Objects;

namespace Hobscure.Main { 
    public class WorldManager : MonoBehaviour {

        public static WorldManager instance;

        [Inject]
        PlayerManager player;

        [Inject]
        ObjectManager objectManager;

        [Inject]
        ItemManager itemManager;

        [Inject]
        DiContainer container;

        [SerializeField]
        Transform machineObjectContainer;

        public List<MachineObject> placedMachines = new List<MachineObject>();

        // Use this for initialization
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            //either load the savegame
            //or start a new game
            if (SaveLoadGameManager.currentGame != null)
            {
                LoadBuild(SaveLoadGameManager.currentGame);
            }
            else
            {
                NewGameBuild();
            }

        }

        public void NewGameBuild()
        {
            player.transform.SetParent(transform, false);
            player.transform.localPosition = new Vector3(0, 11f, 0f);

            //Start Inventory
            player.inventory.AddItem(itemManager.GetItemByName("wood_block"));
            player.inventory.AddItem(itemManager.GetItemByName("shipping_crate"));
            player.inventory.AddItem(itemManager.GetItemByName("saw_block"));
            player.inventory.AddItem(itemManager.GetItemByName("bone"));
            player.inventory.AddItem(itemManager.GetItemByName("wooden_crate"));
            player.inventory.AddItem(itemManager.GetItemByName("bone_carve_table"));
            player.inventory.AddItem(itemManager.GetItemByName("bone_sculpture"));
            player.inventory.AddItem(itemManager.GetItemByName("hauler_imp"));
        }

        public void LoadBuild(SaveGame saveGame)
        {
            EmptyWorld();
            LoadPlayer(saveGame);
            LoadMachines(saveGame);
        }

        void LoadPlayer(SaveGame saveGame)
        {
            player.transform.position = saveGame.player.playerPosition.vector3;
            player.playerCamera.transform.eulerAngles = saveGame.player.playerRotation.vector3;

            player.inventory.model.itemCollection = saveGame.player.inventory.itemsAsList(itemManager);
        }

        void LoadMachines(SaveGame saveGame)
        {
            placedMachines = new List<MachineObject>();
            for (int i = 0; i < saveGame.machineObjects.Count; i++)
            {
                Item item = itemManager.GetItemByName(saveGame.machineObjects[i].item.name);
                var machineObject = saveGame.machineObjects[i];

                //TODO: Save orientation and add where now says Vector3
                var placeMachineObject = PlaceMachineObject(machineObject.position.vector3, new Vector3(0f,0f,0f), item);

                var itemList = machineObject.saveInventory.itemsAsList(itemManager);
                placeMachineObject.inventoryManager.LoadInventory(itemList);
            }
        }

        public void EmptyWorld()
        {
            foreach (Transform child in machineObjectContainer)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        //place type object at position, get position from raytrace/grid and lookat
        public MachineObject PlaceMachineObject(Vector3 position, Vector3 rotation, Item item)
        {
            var placedItem = container.InstantiatePrefab(objectManager.GetObjectByName(item.name));
            placedItem.transform.localPosition = position;
            placedItem.transform.localEulerAngles = SnapRotation(rotation);
            placedItem.transform.SetParent(machineObjectContainer);
            var machineObject = placedItem.GetComponent<MachineObject>();
            machineObject.item = item;

            placedMachines.Add(machineObject);

            return machineObject;
        }

        private Vector3 SnapRotation(Vector3 rotation)
        {
            rotation.x = Mathf.Round(rotation.x / 90) * 90;
            rotation.y = Mathf.Round(rotation.y / 90) * 90;
            rotation.z = Mathf.Round(rotation.z / 90) * 90;
            return rotation;
        }

        //TODO: make sure the remove function for MachineObjects also resides here

    }
}
