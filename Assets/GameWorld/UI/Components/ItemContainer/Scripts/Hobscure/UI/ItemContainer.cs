using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using Zenject;
using Kuchen;
using Hobscure.Screens;

namespace Hobscure.UI
{
    public class ItemContainer : MonoBehaviour, iComponent, IPointerClickHandler
    {

        [SerializeField]
        Image image;

        [SerializeField]
        Transform amountTextHolder;

        [SerializeField]
        GameObject selectedOverlay;

        [Inject]
        CustomTextField textField;

        public CustomTextFieldStyle textStyle;

        public ItemContainerModel model;

        void Start()
        {
            textField.transform.SetParent(amountTextHolder, false);
        }

        public void ApplyModel(iComponentModel data)
        {
            model = (ItemContainerModel)data;
            textField.SetText(model.item.name.ToString());//todo: replace with amount when introduced
           
            textField.SetTextStyle(textStyle);
            image.sprite = model.item.img;
            selectedOverlay.SetActive(model.selected);
        }

        public void OnPointerClick(PointerEventData p)
        {
            Flip();
            this.Publish(ScreenSignals.ScrollList_Changed, this);
        }

        public void Flip()
        {
            model.selected = !model.selected;
            UpdateState();
        }

        public void UpdateState()
        {
            selectedOverlay.SetActive(model.selected);
        }
    }
}
