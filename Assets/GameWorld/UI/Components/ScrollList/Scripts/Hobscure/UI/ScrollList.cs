using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using Zenject;
using Kuchen;
using Hobscure.Screens;

namespace Hobscure.UI
{
    public class ScrollList : MonoBehaviour, iComponent, iScreenTransferSub
    {
        [Inject]
        DiContainer Container;

        [SerializeField]
        Transform gridContentHolder;

        public ScrollListModel model;

        public GameObject prefabEmptyGridItem;

        public List<ItemContainer> gridItems;

        public iScreenTransferSubModel GetModel()
        {
            return model as iScreenTransferSubModel;
        }

        public void ApplyModel(iComponentModel data)
        {
            Reset();

            model = (ScrollListModel)data;
            if(model != null && model.gridItems != null) { 
                for (int i = 0; i < model.gridItems.Count; i++)
                {  
                    var item = Container.Resolve<ItemContainer>();
                    item.ApplyModel(model.gridItems[i]);
                    item.transform.SetParent(gridContentHolder, false);
                    gridItems.Add(item);
                }
            }
            GenerateGrid();
        }

        private void GenerateGrid()
        {
            int space_left = model.maxContainAmount - model.gridItems.Count;
            for (int i = 0; i < space_left; i++)
            {
                Instantiate(prefabEmptyGridItem, gridContentHolder, false);
            }
        }

        private void Reset()
        {
            foreach (Transform child in gridContentHolder)
            {
                GameObject.Destroy(child.gameObject);
            }

            gridItems = new List<ItemContainer>();
        }

    }
}