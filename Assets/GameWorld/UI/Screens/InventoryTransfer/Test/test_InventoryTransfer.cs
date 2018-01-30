using UnityEngine;
using System.Collections;
using Hobscure.UI;
using Hobscure.Screens;
using Hobscure.Items;

namespace Hobscure.Test
{
    [CreateAssetMenu(fileName = "Data", menuName = "Hobscure/Tests/Inventory", order = 1)]
    public class test_InventoryTransfer : ScriptableObject, iTestData
    {
        public ScreenInventoryTransferModel[] inventory;

        public test_ScrollList testScrollList;

        public ItemDataWrapper[] machineItems;

        public iComponentModel[] GetData()
        {



            return inventory;
        }
    }

}
