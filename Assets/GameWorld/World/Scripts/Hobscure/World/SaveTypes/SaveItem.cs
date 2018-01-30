using UnityEngine;
using System;
using Hobscure.Items;

namespace Hobscure.World {
    [Serializable]
    public class SaveItem {

        public string name;

        public SaveItem(Item item)
        {
            this.name = item.name;
        }
	
    }
}