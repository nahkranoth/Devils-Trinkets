using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hobscure.Items;


namespace Hobscure.World.Market { 
    public class MarketModel {

        public List<Item> itemCollection = new List<Item>();

        public int maxMarketContainAmount;

        public MarketModel(int _maxMarketContainAmount)
        {
            maxMarketContainAmount = _maxMarketContainAmount;
        }

    }
}