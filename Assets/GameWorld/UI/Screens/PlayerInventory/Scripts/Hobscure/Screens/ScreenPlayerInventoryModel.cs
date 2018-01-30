using UnityEngine;
using System;
using System.Collections;
using Hobscure.UI;

namespace Hobscure.Screens { 
    [Serializable]
    public class ScreenPlayerInventoryModel : iComponentModel
    {
        public ScrollListModel localInventoryScroll;
        public float cashAmount;

        public ScreenPlayerInventoryModel(int maxContainAmount)
        {
            localInventoryScroll = new ScrollListModel(maxContainAmount);
        }

    }
}