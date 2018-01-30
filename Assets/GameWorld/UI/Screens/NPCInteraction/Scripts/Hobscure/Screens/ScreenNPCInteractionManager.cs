using UnityEngine;
using System.Collections;
using Zenject;
using Hobscure.Player;
using Hobscure.NPC;
using Hobscure.Objects;

namespace Hobscure.Screens { 
    public class ScreenNPCInteractionManager : IScreenManager
    {

        [Inject]
        ScreenNPCInteraction view;

        [Inject]
        PlayerManager playerManager;

        NPCManager npc;

        ScreenNPCInteractionModel model;

        public void ConstructViewModel()
        {
            if (playerManager.NPCLookingAt() != null)
            {
                npc = playerManager.NPCLookingAt();
            }

            model = new ScreenNPCInteractionModel() { name = npc.model.name };

            if (npc.model.commands.Count > 0 && npc.model.commands[0] != null) model.routeStart = npc.model.commands[0].gameObject.transform;
            if (npc.model.commands.Count > 1 && npc.model.commands[1] != null) model.routeDestination = npc.model.commands[1].gameObject.transform;

            Debug.Log("COnstruct View model for: "+ npc.model.name);

            view.ApplyModel(model);
        }

        public void AddRoute(int index, ObjectInventoryManager obj, INPCCommand command)
        {
            npc.AddCommand(index, obj, command);
        }

        public void Show()
        {
            view.gameObject.SetActive(true);
        }

        public void Close()
        {
            view.gameObject.SetActive(false);
        }

    }
}