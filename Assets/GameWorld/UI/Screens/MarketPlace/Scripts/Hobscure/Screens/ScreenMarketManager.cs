using UnityEngine;
using System.Collections;
using System.Linq;
using Zenject;
using Kuchen;
using Hobscure.Player;
using Hobscure.UI;
using Hobscure.Items;
using Hobscure.World.Market;

namespace Hobscure.Screens
{
    public class ScreenMarketManager : IScreenManager
    {

        [Inject]
        DiContainer container;

        [Inject]
        PlayerInventoryManager playerInventory;

        [Inject]
        MarketManager marketManager;

        [Inject]
        PlayerManager playerManager;

        [Inject]
        ScreenMarket view;

        Subscriber sub;

        float totalSelectedPrice;

        public void ConstructViewModel()
        {
            var model = new ScreenMarketModel(playerInventory.model.maxInventoryContainAmount, marketManager.model.maxMarketContainAmount);
            model.cashAmount = playerInventory.GetCashAmount();

            for (int i = 0; i < marketManager.model.itemCollection.Count; i++)
            {
                model.shopInventoryScroll.gridItems.Add(new ItemContainerModel() { item = marketManager.model.itemCollection[i] });
            }

            for (int i = 0; i < playerInventory.model.itemCollection.Count; i++)
            {
                model.localInventoryScroll.gridItems.Add(new ItemContainerModel() { item = playerInventory.model.itemCollection[i] });
            }

            view.ApplyModel(model);

            //needs unsubscription on close?
            sub = new Subscriber();
            sub.Subscribe(ScreenSignals.ScrollList_Changed, (ItemContainer item) => { this.ScrollListChanged(item); });
        }

        public void ScrollListChanged(ItemContainer scrollItem = null)
        {
            //Set price
            var allSelected = view.model.shopInventoryScroll.gridItems.FindAll(p => p.selected == true).Select(p => p.item).ToList();
            totalSelectedPrice = allSelected.Select(p => p.basePrice).Sum();
            view.marketInfo.SetPrice(totalSelectedPrice);
        }

        public void BuyItems(ScrollListModel shop, ScrollListModel player)
        {

            if (totalSelectedPrice <= playerInventory.model.money) { 
                var toTransfer = shop.gridItems.Where(p => p.selected == true).Select(p => p.Clone()).ToList();

                //Add the to transfer items to the player viewmodel
                player.gridItems = player.gridItems.Concat(toTransfer).ToList();

                view.shopScrollList.ApplyModel(view.shopScrollList.model);
                view.localScrollList.ApplyModel(view.localScrollList.model);

                playerInventory.model.money -= totalSelectedPrice;

                UpdateModel();
                view.UpdateModel();
            }
        }

        public void UpdateModel()
        {
            view.model.cashAmount = playerInventory.model.money;
            playerInventory.model.itemCollection = view.localScrollList.model.gridItems.Select(x => x.item).ToList();
            marketManager.model.itemCollection = view.shopScrollList.model.gridItems.Select(x => x.item).ToList();
        }

        public void Close()
        {
            view.gameObject.SetActive(false);
        }

        public void Show()
        {
            view.gameObject.SetActive(true);
        }
    }
}