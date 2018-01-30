using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Hobscure.UI
{
    [CreateAssetMenu(fileName = "Data", menuName = "Hobscure/IconButtonStyle", order = 2)]
    public class IconButtonStyle : GeneralButtonStyle
    {
        public Color iconColor;
        public Color iconColorDisabled;
        public Sprite sprite;
    }
}