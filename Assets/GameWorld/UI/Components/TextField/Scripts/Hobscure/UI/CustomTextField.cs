using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Hobscure.Main;

namespace Hobscure.UI { 
    public class CustomTextField : MonoBehaviour {

        [SerializeField]
        Text textField;

	    public void SetText(string txt)
        {
            textField.text = txt;
        }

        public void SetTextColor(Color clr)
        {
            textField.color = clr;
        }

        public void SetTextStyle(CustomTextFieldStyle style)
        {
            textField.color = style.textColor;
            textField.font = style.font;
            textField.fontSize = style.fontSize;
            textField.resizeTextForBestFit = style.resize;
            textField.alignment = style.alignment;
        }
    }
}