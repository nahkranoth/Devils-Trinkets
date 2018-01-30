using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Kuchen;

namespace Hobscure.UI
{
    public class IconStateButton : MonoBehaviour
    {
        private IconStateButtonModel[] models;
        private IconStateButtonModel currentModel;
        private int currentState;

        public string command;
        public Image imageField;
        public Button button;

        [SerializeField]
        IconButtonStyle style;

        [SerializeField]
        Image background;

        public void Create(IconStateButtonModel[] models)
        {
            this.models = models;
            SetModel(this.models[0]);
        }

        private void SetModel(IconStateButtonModel model)
        {
            currentModel = model;
            SetStyle(model.style);
        }

        public void ForceState(int state)
        {
            if (state <= this.models.Length) currentState = state;
            SetModel(this.models[currentState]);
        }

        private void IncreaseState()
        {
            currentState++;
            if (currentState == this.models.Length) currentState = 0;
        }

        public void OnClick()
        {
            Debug.Log("state: " + currentState);
            IncreaseState();
            SetModel(this.models[currentState]);
            Publisher.Publish(currentModel.command);
        }

        public void SetStyle(IconButtonStyle style)
        {
            imageField.color = style.iconColor;
            imageField.sprite = style.sprite;
            var colors = button.colors;
            colors.normalColor = style.normalColor;
            colors.highlightedColor = style.highlightColor;
            colors.pressedColor = style.pressedColor;
            colors.disabledColor = style.disabledColor;
            button.colors = colors;

        }
    }
}