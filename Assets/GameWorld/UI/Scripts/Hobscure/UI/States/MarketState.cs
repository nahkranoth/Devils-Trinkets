using UnityEngine;
using Zenject;
using System;
using System.Collections;
using Hobscure.UI;
using Hobscure.Main;
using Hobscure.Player;
using Hobscure.Screens;


public class MarketState : iUIState
{
    DiContainer container;
    UIStateManager stateManager;
    InputManager input;
    PlayerManager player;
    ScreenMarketManager screenManager;

    public MarketState(UIStateManager stateManager)
    {
        this.stateManager = stateManager;
        this.container = stateManager.container;
        this.input = stateManager.input;
        this.player = stateManager.player;
    }

    public void Init()
    {
        stateManager.CameraShow();
        screenManager = container.Resolve<ScreenMarketManager>();
        screenManager.ConstructViewModel();
        screenManager.Show();

        stateManager.ShowScreenSubMenuTabs();
    }

    public void Update()
    {
        if (input.GetButtonDown("Menu") || input.GetButtonDown("Cancel") || input.GetButtonDown("Fire2"))
        {
            stateManager.SwitchStates(new Hobscure.UI.IdleState(stateManager));
            player.playerStateManager.SwitchStates(new WalkState(player.playerStateManager));
        }
    }

    public void Exit()
    {
        stateManager.HideScreenSubMenuTabs();
        stateManager.CameraHide();
        screenManager.Close();
        Debug.Log("Exit Market");
    }

}
