using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Hobscure.Items;
using Hobscure.UI;
using Hobscure.Player;
using Zenject;
using Hobscure.Objects;

namespace Hobscure.Screens { 
    public class ScreenInventoryTransferManager: IScreenManager
    {

        [Inject]
        DiContainer container;

        [Inject]
        PlayerInventoryManager playerInventory;

        [Inject]
        PlayerManager playerManager;

        [Inject]
        ScreenInventoryTransfer view;

        public ObjectInventoryManager currentObject;

        public void ConstructViewModel()
        {
            //TODO: This needs to be made more robust. It now sometimes comes back with a wrong object
            //object view was opened from
            currentObject = playerManager.WorldObjectLookingAt();
            var model = new ScreenInventoryTransferModel(currentObject, playerInventory.model.itemCollection, currentObject.inventory.itemCollection);
            view.ApplyModel(model);
        }

        public void UpdateModel()
        {
            playerInventory.model.itemCollection = view.localScrollList.model.gridItems.Select(x => x.item).ToList();
            playerManager.WorldObjectLookingAt().inventory.itemCollection = view.remoteSubmodule.GetModel().GetAllItems();
        }

        public void TransferItems(iScreenTransferSubModel local, iScreenTransferSubModel remote, bool toPlayer)
        {
            var ToTransfer = local.GetSelectedContainers();

            if (currentObject.CanReceive(local.GetSelectedAsItems()) || toPlayer)
            {
                //Reset remote model to only include the non selected
                local.RemoveSelected();

                //Add the to transfer items to the local model
                remote.MergeWithInventory(ToTransfer);
                remote.DeselectAll();

                view.UpdateModels();
                view.ScrollListChanged();
                UpdateModel();
            }else
            {
                Debug.Log("This inventory cannot receive these items");
            }
        }

        public void Show()
        {
            view.gameObject.SetActive(true);
        }

        public void Close()
        {
            view.gameObject.SetActive(false);
        }

    }
}