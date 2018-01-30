using Hobscure.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hobscure.Items
{
    [CreateAssetMenu(fileName = "Data", menuName = "Hobscure/ItemDataWrapper", order = 1)]
    public class ItemDataWrapper : ScriptableObject
    {
        public Item itemData;
    }
}