using UnityEngine;
using System.Collections;
using Hobscure.Objects;
using Zenject;
using Hobscure.Items;
using Hobscure.Screens;

namespace Hobscure.Objects
{
    public class CarveTable : MachineObject
    {
        [Inject]
        ItemManager itemManager;

        [Inject]
        ScreenInventoryTransferManager transferManager;

        bool findingObjectToProcess = true;

        void Start()
        {
            StartCoroutine(FindItemToProcess());
            inventoryManager.inventory.inventoryType = ObjectInventoryTypes.Type.Two;
        }

        IEnumerator FindItemToProcess()
        {
            while (findingObjectToProcess)
            {
                var item = inventoryManager.inventory.itemCollection.Find(x => x.name == "bone");
                
                if (item != null)
                {
                    inventoryManager.inventory.itemCollection.Remove(item);
                    inventoryManager.inventory.itemCollection.Add(itemManager.GetItemByName("bone_sculpture"));
                    transferManager.ConstructViewModel();
                }
                //TODO: start this wait for every item added to, not constantly run
                yield return new WaitForSeconds(5f);
            }
        }
    }
}
