using UnityEngine;
using System;

using System.Collections;
using Hobscure.UI;
using Hobscure.Screens;

namespace Hobscure.Items
{
    [Serializable]
    public class Item
    {
        public string name;
        public string displayName;
        public Sprite img;
        public string description;

        //market
        public bool placeable;
        public bool sellable;
        public float basePrice;
        
    }
}
