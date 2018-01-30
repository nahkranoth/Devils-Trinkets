using UnityEngine;
using System.Collections;
using System.Linq;
using Zenject;
using Kuchen;
using Hobscure.UI;
using Hobscure.Main;
using Hobscure.Player;

namespace Hobscure.Screens { 
    public class ScreenInventoryTransfer : MonoBehaviour, iComponent
    {
        [Inject]
        PlayerInventoryManager playerInventory;

        [Inject]
        IconButton localTransferButton;

        [Inject]
        IconButton remoteTransferButton;

        [Inject]
        public ScrollList localScrollList;

        [Inject]
        public ScrollList remoteScrollList;

        [Inject]
        public ScreenMachineProcessor screenMachineProcessor;

        [Inject]
        public ScreenInventoryTransferManager manager;

        [SerializeField]
        Transform localTransferButtonHolder;

        [SerializeField]
        Transform remoteTransferButtonHolder;

        [SerializeField]
        Transform localScrollListHolder;

        [SerializeField]
        Transform remoteScrollListHolder;

        public ScreenInventoryTransferModel model;

        public iScreenTransferSub remoteSubmodule;

        void Start()
        {
            localScrollList.transform.SetParent(localScrollListHolder, false);

            remoteScrollList.transform.SetParent(remoteScrollListHolder, false);
            remoteScrollList.gameObject.SetActive(false);
            screenMachineProcessor.transform.SetParent(remoteScrollListHolder, false);
            screenMachineProcessor.gameObject.SetActive(false);
            BuildTransferButtons();
        }

        public void ApplyModel(iComponentModel data)
        {
            model = data as ScreenInventoryTransferModel;
            
            localScrollList.ApplyModel(model.localInventoryScroll);
            
            if (model.remoteInventoryType == ObjectInventoryTypes.Type.Scroll)
            {
                remoteSubmodule = remoteScrollList;
            }
            else if (model.remoteInventoryType == ObjectInventoryTypes.Type.Two)
            {
                remoteSubmodule = screenMachineProcessor;
            }

            remoteSubmodule.ApplyModel(model.remoteInventory as iComponentModel);
            var monoSubmodule = remoteSubmodule as MonoBehaviour;
            monoSubmodule.gameObject.SetActive(true);
        }

        public void UpdateModels()
        {
            remoteSubmodule.ApplyModel(remoteSubmodule.GetModel() as iComponentModel);
            localScrollList.ApplyModel(localScrollList.GetModel() as iComponentModel);
        }

        void OnEnable()
        {
            this.Subscribe(ScreenSignals.ScrollList_Changed, () => { this.ScrollListChanged(); });
        }

        void OnDisable()
        {
            this.Unsubscribe(ScreenSignals.ScrollList_Changed);
            remoteScrollList.gameObject.SetActive(false);
            screenMachineProcessor.gameObject.SetActive(false);
        }

        void BuildTransferButtons()
        {
            localTransferButton.transform.SetParent(localTransferButtonHolder, false);
            localTransferButtonHolder.GetComponent<IconButtonStyleSetter>().SetStyle();
            localTransferButton.Create(new IconButtonModel(ScreenInventoryTransferSignals.localTransferButtonPressed));
            localTransferButton.button.interactable = false;

            remoteTransferButton.transform.SetParent(remoteTransferButtonHolder, false);
            remoteTransferButtonHolder.GetComponent<IconButtonStyleSetter>().SetStyle();
            remoteTransferButton.Create(new IconButtonModel(ScreenInventoryTransferSignals.remoteTransferButtonPressed));
            remoteTransferButton.button.interactable = false;

            this.Subscribe(ScreenInventoryTransferSignals.localTransferButtonPressed, () => { manager.TransferItems(model.localInventoryScroll, model.remoteInventory, false); });
            this.Subscribe(ScreenInventoryTransferSignals.remoteTransferButtonPressed, () => { manager.TransferItems(model.remoteInventory, model.localInventoryScroll, true); });
        }

        public void ScrollListChanged()
        {
            localTransferButton.button.interactable = model.localInventoryScroll.IsActive();
            remoteTransferButton.button.interactable = model.remoteInventory.IsActive();
        }

    }
}