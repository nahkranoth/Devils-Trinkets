using UnityEngine;
using System;
using System.Collections;
using Hobscure.UI;

namespace Hobscure.Screens {
    [Serializable]
    public class ScreenNPCInteractionModel: iComponentModel
    {
        public string name;
        public Transform routeStart;
        public Transform routeDestination;
    }
}
