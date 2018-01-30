using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Zenject;
using Kuchen;

namespace Hobscure.UI
{
    public class GeneralButton : MonoBehaviour
    {

        public string command;
        public Transform textFieldHolder;
        public Button button;

        [Inject]
        CustomTextField textField;

        [SerializeField]
        GeneralButtonStyle style;

        void Start()
        {
            textField.transform.SetParent(textFieldHolder, false);
            SetStyle(style);
        }

        void SetStyle(GeneralButtonStyle style)
        {
            var colors = button.colors;
            colors.normalColor = style.normalColor;
            colors.highlightedColor = style.highlightColor;
            colors.pressedColor = style.pressedColor;
            colors.disabledColor = style.disabledColor;
            button.colors = colors;
            textField.SetTextColor(style.textColor);
        }

        public void OnClick()
        {
            Publisher.Publish(command);
        }

        public void Create(GeneralButtonModel button)
        {
            command = button.command;
            textField.SetText(button.text);
        }
    }
}