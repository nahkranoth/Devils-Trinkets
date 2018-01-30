using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using Zenject;
using Hobscure.Items;
using Hobscure.Screens;
using Hobscure.Player;

namespace Hobscure.Objects { 
    public class ShippingCrate : MachineObject
    { 

        [Inject]
        ItemManager itemManager;

        [Inject]
        ScreenInventoryTransferManager transferManager;

        [Inject]
        ScreenHeaderManager screenHeaderManager;

        bool findingObjectToProcess = true;

        void Start()
        {
            StartCoroutine(FindItemToProcess());
        }

        IEnumerator FindItemToProcess()
        {
            while (findingObjectToProcess) {
                var item = inventoryManager.inventory.itemCollection.Find(x => x.sellable == true);

                if (item != null)
                {
                    inventoryManager.inventory.itemCollection.Remove(item);
                    playerManager.inventory.AddCashAmount(item.basePrice); //price to sell it for
                    transferManager.ConstructViewModel();
                    screenHeaderManager.ConstructViewModel();//Update header
                }

                yield return new WaitForSeconds(5f);
            }
        }
    }
}