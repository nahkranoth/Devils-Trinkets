using UnityEngine;

using System;
using System.Collections.Generic;
using Zenject;
using Hobscure.Main;
using Hobscure.Items;

namespace Hobscure.World
{
    [Serializable]
    public class SaveGame
    {
        public SavePlayer player;
        public List<SaveMachineObject> machineObjects = new List<SaveMachineObject>();

        public SaveGame(DiContainer container)
        {
            player = new SavePlayer(container);

            //Parse all MachineObjects
            for (int i = 0; i < WorldManager.instance.placedMachines.Count; i++)
            {
                SaveMachineObject s_machine = new SaveMachineObject(WorldManager.instance.placedMachines[i]);
                machineObjects.Add(s_machine);
            }
            
        }
        //List of all NPC's
        //List of all level stats
    }
}