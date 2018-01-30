using Hobscure.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Hobscure.Screens { 
    public class ScreenMachineProcessor : MonoBehaviour, iComponent, iScreenTransferSub
    {
        [Inject]
        DiContainer Container;

        public ScreenMachineProcessorModel model;

        [SerializeField]
        Transform inputContainer;
        Transform inputItem;

        [SerializeField]
        Transform outputContainer;
        Transform outputItem;

        public iScreenTransferSubModel GetModel()
        {
            return model as iScreenTransferSubModel;
        }

        public void ApplyModel(iComponentModel data)
        {
            Reset();
            model = (ScreenMachineProcessorModel)data;

             if(model != null) {
                if(model.inputItem != null) { 
                    var itemContainerInput = Container.Resolve<ItemContainer>();
                    itemContainerInput.ApplyModel(model.inputItem);
                    inputItem = itemContainerInput.transform;
                    inputItem.SetParent(inputContainer, false);
                }

                if (model.outputItem != null)
                {
                    var itemContainerOutput = Container.Resolve<ItemContainer>();
                    itemContainerOutput.ApplyModel(model.outputItem);
                    outputItem = itemContainerOutput.transform;
                    outputItem.SetParent(outputContainer, false);
                }
            }
        }

        private void Reset()
        {
            //destroy all views
            if (inputItem != null)
            {
                GameObject.Destroy(inputItem.gameObject);
                inputItem = null;
            }
            if (outputItem != null)
            {
                GameObject.Destroy(outputItem.gameObject);
                outputItem = null;
            }
        }
    }
}