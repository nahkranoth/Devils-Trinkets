using UnityEngine;
using System.Collections;
using System.Linq;
using Zenject;
using Kuchen;
using Hobscure.UI;
using Hobscure.Main;
using Hobscure.Player;
using Hobscure.Items;

namespace Hobscure.Screens { 
    public class ScreenPlayerInventory : MonoBehaviour, iComponent
    {

        [Inject]
        public ScrollList localScrollList;

        [Inject]
        IconButton placeButton;

        [Inject]
        PlayerManager playerManager;

        [Inject]
        CustomTextField infoTextfield;

        [SerializeField]
        IconButtonStyle placeButtonStyle;

        [SerializeField]
        Transform localScrollListHolder;

        [SerializeField]
        Transform placeButtonHolder;

        [SerializeField]
        Transform infoPanelHolder;

        [SerializeField]
        CustomTextFieldStyle infoPanelStyle;

        [HideInInspector]
        public ScreenPlayerInventoryModel model;

        Item toPlace;

        void Start()
        {
            localScrollList.transform.SetParent(localScrollListHolder, false);
            infoTextfield.transform.SetParent(infoPanelHolder, false);
            infoTextfield.SetTextStyle(infoPanelStyle);
            infoTextfield.SetText("");
            placeButton.transform.SetParent(placeButtonHolder, false);
            placeButton.SetInteract(false);
        }

        void OnEnable()
        {
            this.Subscribe(ScreenSignals.ScrollList_Changed, (ItemContainer item) => { this.ScrollListChanged(item); });
            this.Subscribe(ScreenPlayerInventorySignals.placeButtonClicked, () => { this.PlaceButtonClicked(); });
        }

        void OnDisable()
        {
            placeButton.SetInteract(false);
            this.Unsubscribe(ScreenSignals.ScrollList_Changed);
            this.Unsubscribe(ScreenPlayerInventorySignals.placeButtonClicked);
        }

        public void ApplyModel(iComponentModel data)
        {
            model = data as ScreenPlayerInventoryModel;
            localScrollList.ApplyModel(model.localInventoryScroll);
            placeButton.SetStyle(placeButtonStyle);
            placeButton.Create(new IconButtonModel(ScreenPlayerInventorySignals.placeButtonClicked));
        }

        void PlaceButtonClicked()
        {
            //Force States To be able To place
            playerManager.PlaceItem(toPlace);
            UIStateManager.instance.SwitchToIdle();
        }

        public void ScrollListChanged(ItemContainer item)
        {
            //Restrict to only one Selection
            for (int i = 0; i < localScrollList.gridItems.Count; i++)
            {
                if (localScrollList.gridItems[i] != item) { 
                    localScrollList.gridItems[i].model.selected = false;
                    localScrollList.gridItems[i].UpdateState();
                    
                }
            }

            infoTextfield.SetText("");
            if (item.model.selected) infoTextfield.SetText(item.model.item.description);

            placeButton.SetInteract(item.model.item.placeable && item.model.selected);
            toPlace = item.model.item;

        }
    }
}