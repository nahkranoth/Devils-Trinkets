using UnityEngine;
using System.Collections;
using Zenject;
using Kuchen;
using Hobscure.UI;
using Hobscure.NPC;
using Hobscure.Player;
using System;

namespace Hobscure.Screens { 
    public class ScreenNPCInteraction : MonoBehaviour, iComponent
    {

        public Transform startButtonContainer;
        public IconButtonStyle[] startButtonStyles;

        public Transform destinationButtonContainer;
        public IconButtonStyle[] destinationButtonStyles;

        public Transform toggleStateButtonContainer;
        public IconButtonStyle[] toggleStateButtonStyles;

        public Transform textFieldHolder;

        [Inject]
        ScreenNPCInteractionManager manager;

        [Inject]
        CustomTextField nameText;

        [Inject]
        IconStateButton startButton;

        [Inject]
        IconStateButton destinationButton;

        [Inject]
        IconStateButton toggleStateButton;

        [Inject]
        PlayerManager playerManager;

        ScreenNPCInteractionModel model;

        NPCManager currentNPC;


        //TODO: Also show whats in NPC's inventory and make it able to grab

        void Start()
        {
            startButton.transform.SetParent(startButtonContainer, false);
            destinationButton.transform.SetParent(destinationButtonContainer, false);
            toggleStateButton.transform.SetParent(toggleStateButtonContainer, false);
            nameText.transform.SetParent(textFieldHolder, false);
            
        }

        public void ApplyModel(iComponentModel data)
        {
            currentNPC = playerManager.NPCLookingAt();

            model = data as ScreenNPCInteractionModel;

            nameText.SetText(model.name);

            IconStateButtonModel[] startModelList = new IconStateButtonModel[] {
                new IconStateButtonModel(ScreenNPCInteractionSignals.removeRouteStart, startButtonStyles[0]),
                new IconStateButtonModel(ScreenNPCInteractionSignals.setRouteStart, startButtonStyles[1])
                };
            startButton.Create(startModelList);
            startButton.ForceState(Convert.ToInt32(model.routeDestination != null));

            IconStateButtonModel[] destinationModelList = new IconStateButtonModel[] {
                new IconStateButtonModel(ScreenNPCInteractionSignals.removeRouteDestination, destinationButtonStyles[1]),
                new IconStateButtonModel(ScreenNPCInteractionSignals.setRouteDestination, destinationButtonStyles[0])
                };
            destinationButton.Create(destinationModelList);
            destinationButton.ForceState(Convert.ToInt32(model.routeDestination != null));

            IconStateButtonModel[] toggleModelList = new IconStateButtonModel[] {
                new IconStateButtonModel(ScreenNPCInteractionSignals.pauseRoutes, toggleStateButtonStyles[1]),
                new IconStateButtonModel(ScreenNPCInteractionSignals.runRoutes, toggleStateButtonStyles[0])
                };
            toggleStateButton.Create(toggleModelList);
            toggleStateButton.ForceState(Convert.ToInt32(currentNPC.routeManager.running));

        }

        void OnEnable()
        {
            this.Subscribe(ScreenNPCInteractionSignals.runRoutes, () => {currentNPC.ContinueCommandExecution(); });
            this.Subscribe(ScreenNPCInteractionSignals.pauseRoutes, () => {currentNPC.PauseCommandExecution(); });
        }

        void OnDisable()
        {
            this.Unsubscribe(ScreenNPCInteractionSignals.runRoutes);
            this.Unsubscribe(ScreenNPCInteractionSignals.pauseRoutes);
        }


    }
}