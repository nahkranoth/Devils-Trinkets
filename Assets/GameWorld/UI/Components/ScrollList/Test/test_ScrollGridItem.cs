using UnityEngine;
using System.Collections;
using Hobscure.UI;

namespace Hobscure.Test {
    [CreateAssetMenu(fileName = "Data", menuName = "Hobscure/Tests/ScrollGridItem", order = 1)]
    public class test_ScrollGridItem : ScriptableObject, iTestData {
        public ItemContainerModel[] gridItems;

        public iComponentModel[] GetData()
        {
            return  gridItems;
        }
    }

}
