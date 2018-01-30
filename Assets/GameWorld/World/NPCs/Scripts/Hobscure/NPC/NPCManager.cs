using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Kuchen;
using Hobscure.Objects;
using Hobscure.Screens;
using Hobscure.Items;

namespace Hobscure.NPC { 
    public class NPCManager : MachineObject
    {

        public ObjectInventoryModel inventory;
        public NPCModel model = new NPCModel() { name = "Tim" };

        public string myName;
        int commandIndex;
        
        public NPCRouteManager routeManager;
        const float RETRY_COMMAND_TIME = 1f;

        private IEnumerator runCoroutine;

        public bool runningCommandExecution;

        void Start () {
            model.name = Time.time.ToString();
            inventory = new ObjectInventoryModel();
            routeManager = GetComponent<NPCRouteManager>();

        }

        public void AddCommand(int index, ObjectInventoryManager obj, INPCCommand command)
        {
            model.commands.Add(new NPCCommandModel() { index = index, gameObject = obj, destinationCommand = command });
        }

        public void NextCommand()
        {
            if (commandIndex == model.commands.Count) commandIndex = 0;
            model.currentCommand = model.commands.Single(c => { return (c.index == commandIndex); });
            routeManager.NavigateTo(model.currentCommand.gameObject.transform.position, this.ExecuteCommand);
            commandIndex++;
        }

        public void ExecuteCommand()
        {
            runCoroutine = TryCommand(this);
            StartCoroutine(runCoroutine);
        }

        public void ContinueCommandExecution()
        {
            if (!runningCommandExecution) { 
                NextCommand();
                runningCommandExecution = true;
            }
        }

        public void PauseCommandExecution()
        {
            routeManager.PauseRoutes();
            runningCommandExecution = false;
        }

        private IEnumerator TryCommand(NPCManager me)
        {
            while (!model.currentCommand.destinationCommand.Run(me) && runningCommandExecution)
            {
                yield return new WaitForSeconds(RETRY_COMMAND_TIME);
            }
            NextCommand();
        }

    }
}
