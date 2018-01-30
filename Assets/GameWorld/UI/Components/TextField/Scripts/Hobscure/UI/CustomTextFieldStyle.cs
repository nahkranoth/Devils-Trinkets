using UnityEngine;

namespace Hobscure.UI
{
    [CreateAssetMenu(fileName = "Data", menuName = "Hobscure/TextFieldStyle", order = 3)]
    public class CustomTextFieldStyle:ScriptableObject
    {
        public Color textColor;
        public Font font;
        public int fontSize;
        public bool resize;
        public TextAnchor alignment;
    }
}