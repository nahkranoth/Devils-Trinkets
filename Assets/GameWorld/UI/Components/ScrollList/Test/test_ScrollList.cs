using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hobscure.UI;
using Hobscure.Items;

namespace Hobscure.Test
{
    [CreateAssetMenu(fileName = "Data", menuName = "Hobscure/Tests/ScrollList", order = 1)]
    public class test_ScrollList : ScriptableObject, iTestData
    {
        [HideInInspector]
        public List<ItemContainerModel> scrollModels;
        public ItemDataWrapper[] testItems;

        [HideInInspector]
        public ScrollListModel[] scrollList;

        public iComponentModel[] GetData()
        {
            scrollList = new ScrollListModel[1];
            scrollModels = new List<ItemContainerModel>();
            for (int i = 0; i < testItems.Length; i++)
            {
                ItemContainerModel gridItem = new ItemContainerModel();
                gridItem.item = testItems[i].itemData;
                scrollModels.Add(gridItem);
            }
            scrollList[0] = new ScrollListModel(91);//with a max amount of 91
            scrollList[0].gridItems = scrollModels;
            return scrollList;
        }
    }

}
