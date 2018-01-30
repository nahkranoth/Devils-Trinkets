using UnityEngine;
using System.Collections;

namespace Hobscure.UI
{
    public class IconStateButtonModel
    {
        public string command;
        public IconButtonStyle style;
        public IconStateButtonModel(string command, IconButtonStyle style)
        {
            this.command = command;
            this.style = style;
        }
    }
}