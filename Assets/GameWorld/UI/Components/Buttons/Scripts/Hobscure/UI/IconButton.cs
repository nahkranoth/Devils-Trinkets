using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Kuchen;
namespace Hobscure.UI
{
    public class IconButton : MonoBehaviour
    {

        public string command;
        public Image imageField;
        public Button button;

        [SerializeField]
        IconButtonStyle style;

        [SerializeField]
        Image background;

        public void OnClick()
        {
            Publisher.Publish(command);
        }

        public void SetStyle(IconButtonStyle style)
        {
            this.style = style;
            imageField.color = style.iconColor;
            imageField.sprite = style.sprite;
            var colors = button.colors;
            colors.normalColor = style.normalColor;
            colors.highlightedColor = style.highlightColor;
            colors.pressedColor = style.pressedColor;
            colors.disabledColor = style.disabledColor;
            button.colors = colors;
            SetIconColor();
        }

        public void SetInteract(bool state)
        {
            button.interactable = state;
            SetIconColor();
        }

        private void SetIconColor()
        {
            if (button.interactable)
            {
                imageField.color = this.style.iconColor;
            }
            else
            {
                imageField.color = this.style.iconColorDisabled;
            }
        }

        public void Create(IconButtonModel button)
        {
            command = button.command;
        }
    }
}