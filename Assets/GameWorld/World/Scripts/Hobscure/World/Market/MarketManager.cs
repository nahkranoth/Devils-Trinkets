using UnityEngine;
using System.Collections;
using Zenject;
using Hobscure.Items;

namespace Hobscure.World.Market { 
    public class MarketManager {

        public MarketModel model = new MarketModel(12);

        ItemManager itemManager;

        [Inject]
        public MarketManager(ItemManager itemManager)
        {
            this.itemManager = itemManager;
            //the shop inventory
            model.itemCollection.Add(this.itemManager.GetItemByName("wood_block"));
            model.itemCollection.Add(this.itemManager.GetItemByName("bone"));
            model.itemCollection.Add(this.itemManager.GetItemByName("hauler_imp"));
        }

    }
}