using System;
using System.Collections.Generic;
using Hobscure.Items;

namespace Hobscure.Player {
    [Serializable]
    public class PlayerInventoryModel {

        public float money = 0;
        public List<Item> itemCollection;
        public int maxInventoryContainAmount;

        public PlayerInventoryModel(int _maxInventoryContainAmount)
        {
            itemCollection = new List<Item>();
            maxInventoryContainAmount = _maxInventoryContainAmount;
        }
    }
}