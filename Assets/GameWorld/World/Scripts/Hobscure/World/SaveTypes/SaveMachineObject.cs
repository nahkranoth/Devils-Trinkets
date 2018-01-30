using System;
using Hobscure.Objects;

namespace Hobscure.World {
    [Serializable]
    public class SaveMachineObject {

        public SaveItem item;
        public SaveVector3 position;
        public SaveInventory saveInventory;

        public SaveMachineObject(MachineObject machine)
        {
            item = new SaveItem(machine.item);
            position = new SaveVector3(machine.transform.position);
            saveInventory = new SaveInventory(machine.inventoryManager.inventory.itemCollection);
        }
    }
}