using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hobscure.Items;

namespace Hobscure.Objects { 
    public class ObjectInventoryModel  {

        public List<Item> itemCollection;

        public ObjectInventoryTypes.Type inventoryType;

        public ObjectInventoryModel()
        {
            itemCollection = new List<Item>();
        }
    }
}