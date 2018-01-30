using UnityEngine;
using System.Collections;
using Zenject;
using Kuchen;
using Hobscure.Main;
using Hobscure.Screens;
using Hobscure.Player;
using Hobscure.Objects;
using Hobscure.NPC;

namespace Hobscure.UI
{
    public class NPCInteractionState : iUIState
    {

        DiContainer container;
        UIStateManager stateManager;
        InputManager input;
        ScreenNPCInteractionManager screenManager;
        PlayerManager player;
        Subscriber sub;

        public NPCInteractionState(UIStateManager stateManager)
        {
            this.stateManager = stateManager;
            this.container = stateManager.container;
            this.player = stateManager.player;
            this.input = stateManager.input;
            sub = new Subscriber();
        }

        public void SetRouteStart()
        {
            stateManager.CameraHide();
            screenManager.Close();
            player.SelectObject();
            sub.Subscribe(ScreenNPCInteractionSignals.doneRoute, (ObjectInventoryManager obj) => { this.SelectedRouteObject(obj, 0, new NPCGrabCommand()); Debug.Log("SET START: " + obj.name); }).Once();
        }

        public void SelectedRouteObject(ObjectInventoryManager obj, int index, INPCCommand command)
        {
            stateManager.CameraShow();
            screenManager.Show();
            screenManager.AddRoute(index, obj, command);
        }

        public void SetRouteDestination()
        {
            stateManager.CameraHide();
            screenManager.Close();
            player.SelectObject();
            sub.Subscribe(ScreenNPCInteractionSignals.doneRoute, (ObjectInventoryManager obj) => { this.SelectedRouteObject(obj, 1, new NPCDropCommand()); Debug.Log("SET DESTINATION: "+obj.name); }).Once();
        }

        public void Init()
        {
            //TODO: Refactor
            sub.Subscribe(ScreenNPCInteractionSignals.setRouteStart, () => { this.SetRouteStart(); }).Once();
            sub.Subscribe(ScreenNPCInteractionSignals.setRouteDestination, () => { this.SetRouteDestination(); }).Once();

            stateManager.CameraShow();
            screenManager = container.Resolve<ScreenNPCInteractionManager>();
            screenManager.ConstructViewModel();
            screenManager.Show();
        }

        public void Update()
        {
            if (input.GetButtonDown("Menu") || input.GetButtonDown("Cancel") || input.GetButtonDown("Fire2"))
            {
                stateManager.SwitchStates(new IdleState(stateManager));
                player.playerStateManager.SwitchStates(new WalkState(player.playerStateManager));
            }
        }

        public void Exit()
        {
            sub.Unsubscribe();//Make sure to stop listening to the pressing of a button
            stateManager.CameraHide();
            screenManager.Close();
        }
    }
}