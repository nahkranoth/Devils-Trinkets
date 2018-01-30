using Hobscure.Items;
using Hobscure.Screens;
using Hobscure.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hobscure.Test
{
    [CreateAssetMenu(fileName = "Data", menuName = "Hobscure/Tests/MachineProcessor", order = 1)]
    public class test_MachineProcessor : ScriptableObject, iTestData
    {

        ScreenMachineProcessorModel[] model;
        public ItemDataWrapper[] testItems;

        public iComponentModel[] GetData()
        {
            model = new ScreenMachineProcessorModel[1];

            //model[0] = new ScreenMachineProcessorModel();
            //model[0].inputItem = new ItemContainerModel(testItems[0].itemData, false);
            //model[0].outputItem = new ItemContainerModel(testItems[1].itemData, false);

            return model;
        }
    }

}