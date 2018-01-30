using UnityEngine;
using System.Collections;
using System.Linq;
using Hobscure.Objects;
using Hobscure.Items;

namespace Hobscure.NPC { 
    public class NPCDropCommand : INPCCommand {

	  public bool Run(NPCManager npc)
        {
            var inventoryManager = npc.model.currentCommand.gameObject.GetComponent<ObjectInventoryManager>();

            if (npc.inventory.itemCollection.Count > 0)
            {
                Item itemToDrop = npc.inventory.itemCollection.First();

                //TODO: now it checks for only the first item. May it be that an NPC can carry more in the future, pass the whole stack
                if (inventoryManager.CanReceive(itemToDrop))
                {
                    inventoryManager.AddItem(itemToDrop);
                    npc.inventory.itemCollection.Remove(itemToDrop);
                }else
                {
                    Debug.Log("Inventory has no space for this item to be dropped by NPC at this moment");
                    return false;
                }
                return true;
            }
            else
            {
                Debug.Log("No Items In NPC");
                return false;
            }
        }
    }
}