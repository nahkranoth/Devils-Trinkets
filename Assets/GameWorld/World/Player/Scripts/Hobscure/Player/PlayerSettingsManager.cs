using UnityEngine;
using System.Collections;
using System.Linq;

namespace Hobscure.Player
{
    public class PlayerSettingsManager
    {
        readonly PlayerSettings settings;

        public PlayerSettingsManager(PlayerSettings settings)
        {
            this.settings = settings;
        }

        public int GetStartBudget()
        {
            return settings.startBudget;
        }

    }
}

