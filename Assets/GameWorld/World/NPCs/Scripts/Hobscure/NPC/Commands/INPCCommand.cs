using UnityEngine;
using System.Collections;

namespace Hobscure.NPC
{
    public interface INPCCommand
    {

        bool Run(NPCManager npc);

    }
}
