using UnityEngine;
using System.Collections;

namespace Hobscure.UI
{
    [CreateAssetMenu(fileName = "Data", menuName = "Hobscure/GeneralButtonStyle", order = 1)]
    public class GeneralButtonStyle : ScriptableObject
    {
        public string objectName = "GeneralButtonStyle";
        public Color normalColor;
        public Color highlightColor;
        public Color pressedColor;
        public Color disabledColor;
        public Color textColor;
    }
}