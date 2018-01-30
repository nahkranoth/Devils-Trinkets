using System;
using Hobscure.Items;
using Zenject;

namespace Hobscure.Player { 
    [Serializable]
    public class PlayerInventoryManager {
        public PlayerInventoryModel model;

        [Inject]
        public PlayerInventoryManager(PlayerManager playerManager) {
            model = new PlayerInventoryModel(playerManager.maxInventoryContainAmount);
        }

        public void AddItem(Item item)
        {
            model.itemCollection.Add(item);
        }

        public void RemoveItem(Item item)
        {
            model.itemCollection.Remove(item);
        }

        public float GetCashAmount()
        {
            return model.money;
        }

        public void AddCashAmount(float amount)
        {
            model.money += amount;
        }
    }
}