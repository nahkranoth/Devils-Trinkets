using UnityEngine;
using System.Linq;
using Zenject;
using Kuchen;
using Hobscure.Player;
using Hobscure.UI;

namespace Hobscure.Screens {
    public class ScreenMarket : MonoBehaviour, iComponent
    {

        [Inject]
        PlayerInventoryManager playerInventory;

        [Inject]
        IconButton buyButton;

        [Inject]
        [HideInInspector]
        public ScrollList localScrollList;

        [Inject]
        [HideInInspector]
        public ScrollList shopScrollList;

        [Inject]
        ScreenMarketManager manager;

        [Inject]
        CustomTextField textField;

        [Inject]
        public MarketInfo marketInfo;

        [Inject]
        ScreenHeaderManager screenHeaderManager;

        [SerializeField]
        Transform buyButtonHolder;

        [SerializeField]
        Transform localScrollListHolder;

        [SerializeField]
        Transform remoteScrollListHolder;

        [SerializeField]
        Transform textHolder;

        [SerializeField]
        Transform marketInfoHolder;

        [SerializeField]
        IconButtonStyle buyButtonStyle;

        public ScreenMarketModel model;

        void Start()
        {
            textField.transform.SetParent(textHolder, false);
            marketInfo.transform.SetParent(marketInfoHolder, false);
            localScrollList.transform.SetParent(localScrollListHolder, false);
            shopScrollList.transform.SetParent(remoteScrollListHolder, false);

            buyButton.transform.SetParent(buyButtonHolder, false);
            buyButton.Create(new IconButtonModel(ScreenMarketSignals.Buy_Button_Pressed));
            buyButton.SetStyle(buyButtonStyle);
            buyButton.button.interactable = false;
            this.Subscribe(ScreenMarketSignals.Buy_Button_Pressed, () => { this.manager.BuyItems(model.shopInventoryScroll, model.localInventoryScroll); });

        }

        void OnEnable()
        {
            this.Subscribe(ScreenSignals.ScrollList_Changed, (ItemContainer item) => { this.ScrollListChanged(item); });
        }

        void OnDisable()
        {
            this.Unsubscribe(ScreenSignals.ScrollList_Changed);
        }

        public void UpdateModel()
        {
            ScrollListChanged();
            screenHeaderManager.ConstructViewModel(); //Update Header
        }

        public void ApplyModel(iComponentModel data)
        {
            model = data as ScreenMarketModel;

            localScrollList.ApplyModel(model.localInventoryScroll);
            shopScrollList.ApplyModel(model.shopInventoryScroll);

            UpdateModel();
        }

        public void ScrollListChanged(ItemContainer scrollItem = null)
        {

            if(model.localInventoryScroll.gridItems.Any(p => p.selected == true))
            {
                for (int i = 0; i < localScrollList.gridItems.Count; i++)
                {
                    localScrollList.gridItems[i].model.selected = false;
                    localScrollList.gridItems[i].UpdateState();
                }
                return;
            }

            buyButton.button.interactable = model.shopInventoryScroll.gridItems.Any(p => p.selected == true);

        }
    }
}