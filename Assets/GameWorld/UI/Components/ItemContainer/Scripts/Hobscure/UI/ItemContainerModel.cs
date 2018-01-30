using UnityEngine;
using System;
using System.Collections;
using Hobscure.Items;

namespace Hobscure.UI { 
    [Serializable]
    public class ItemContainerModel: iComponentModel
    {
        public Item item;
        public bool selected = false;

        public ItemContainerModel()
        {
          
        }

        public ItemContainerModel(Item _item, bool selected)
        {
            item = _item;
        }

        public ItemContainerModel Clone()
        {
            return new ItemContainerModel (this.item, this.selected);
        }
    }
}