using UnityEngine;
using System.Collections;

namespace Hobscure.UI { 
    public class IconButtonStyleSetter : MonoBehaviour {

        public Object style;


        //must be called when building the item
        public void SetStyle()
        {
            var iconButton = transform.GetComponentInChildren<IconButton>();
            if(iconButton != null)
            {
                iconButton.SetStyle(style as IconButtonStyle);
            }
             
        }

    }
}
