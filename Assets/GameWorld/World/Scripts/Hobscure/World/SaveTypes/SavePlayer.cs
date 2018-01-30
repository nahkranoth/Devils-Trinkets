using UnityEngine;
using System;
using System.Collections.Generic;
using Zenject;
using Hobscure.Player;
using Hobscure.Items;

namespace Hobscure.World
{


    [Serializable]
    public class SavePlayer
    {
        public SaveInventory inventory;
        public float money;

        public SaveVector3 playerPosition;
        public SaveVector3 playerRotation;

        public SavePlayer(DiContainer container)
        {
            var playerInventory = container.Resolve<PlayerInventoryManager>().model;
            this.money = playerInventory.money;
            this.playerPosition = new SaveVector3(container.Resolve<PlayerManager>().transform.position);
            this.playerRotation = new SaveVector3(container.Resolve<PlayerManager>().playerCamera.transform.rotation.eulerAngles);

            List<Item> itemList = new List<Item>();

            for (int i = 0; i < playerInventory.itemCollection.Count; i++)
            {
                itemList.Add(playerInventory.itemCollection[i]);
            }
            inventory = new SaveInventory(itemList);

        }
    }
}