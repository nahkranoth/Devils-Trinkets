using UnityEngine;
using System.Linq;
using Hobscure.Objects;

namespace Hobscure.NPC
{
    public class NPCGrabCommand: INPCCommand
    {
        //TODO: should end up somewhere more globally
        int caryLimit = 1;

        public bool Run(NPCManager npc)
        {
            var inventoryManager = npc.model.currentCommand.gameObject.GetComponent<ObjectInventoryManager>();
            Debug.Log("NPC Grab Command for: "+ npc.model.name);
            if (inventoryManager.inventory.itemCollection.Count > 0 && npc.inventory.itemCollection.Count < caryLimit)
            {
                var grabbedItem = inventoryManager.DispatchItem();

                if(grabbedItem != null) {
                    Debug.Log("Proceed to grab");
                    npc.inventory.itemCollection.Add(grabbedItem);
                    return true;
                }else
                {
                    return false;
                }
            }
            else
            {
                Debug.Log("NO Item Here");
                return false;
            }
        }
    }
}