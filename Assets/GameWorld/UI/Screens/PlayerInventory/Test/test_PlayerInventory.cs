using UnityEngine;
using System.Collections;
using Hobscure.UI;
using Hobscure.Screens;

namespace Hobscure.Test
{
    [CreateAssetMenu(fileName = "Data", menuName = "Hobscure/Tests/PlayerInventory", order = 1)]
    public class test_PlayerInventory : ScriptableObject, iTestData
    {
        public ScreenPlayerInventoryModel[] inventory;

        public iComponentModel[] GetData()
        {
            return inventory;
        }
    }

}
