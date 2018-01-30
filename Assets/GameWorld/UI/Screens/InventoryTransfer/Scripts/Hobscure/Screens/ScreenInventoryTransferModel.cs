using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Hobscure.UI;
using Hobscure.Items;
using Hobscure.Objects;

namespace Hobscure.Screens { 
    [Serializable]
    public class ScreenInventoryTransferModel: iComponentModel
    {
        public ScrollListModel localInventoryScroll;
        public iScreenTransferSubModel remoteInventory;
        public ObjectInventoryTypes.Type remoteInventoryType;

        public ScreenInventoryTransferModel(ObjectInventoryManager worldObject , List<Item> local, List<Item> remote) {
            remoteInventoryType = worldObject.inventory.inventoryType;

            localInventoryScroll = new ScrollListModel(worldObject.containLimit);

            if(remoteInventoryType == ObjectInventoryTypes.Type.Scroll)
            {
                remoteInventory = new ScrollListModel(worldObject.containLimit);
            }else
            {
                remoteInventory = new ScreenMachineProcessorModel(worldObject);
            }

            localInventoryScroll.AddContainers(local);
            remoteInventory.AddContainers(remote);
        }
    }
}