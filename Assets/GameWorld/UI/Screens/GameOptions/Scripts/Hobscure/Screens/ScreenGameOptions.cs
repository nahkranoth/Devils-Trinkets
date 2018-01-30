using UnityEngine;
using System.Collections;
using Zenject;
using Kuchen;
using Hobscure.Main;
using Hobscure.UI;
using Hobscure.World;
using Hobscure.Player;

namespace Hobscure.Screens
{
    public class ScreenGameOptions : MonoBehaviour
    {
        [Inject]
        DiContainer container;

        [Inject]
        GeneralButton saveButton;

        [Inject]
        GeneralButton loadButton;

        [Inject]
        ScreenGameOptionsManager manager;

        [Inject]
        PlayerManager playerManager;

        [SerializeField]
        Transform saveButtonContainer;

        [SerializeField]
        Transform loadButtonContainer;

        // Use this for initialization
        void Start()
        {
            saveButton.transform.SetParent(saveButtonContainer, false);
            saveButton.Create(new GeneralButtonModel(ScreenGameOptionsSignals.saveGame, "Save"));
            this.Subscribe(ScreenGameOptionsSignals.saveGame, () => { this.OnSaveGameButton(); });

            loadButton.transform.SetParent(loadButtonContainer, false);
            loadButton.Create(new GeneralButtonModel(ScreenGameOptionsSignals.loadGame, "Load"));
            this.Subscribe(ScreenGameOptionsSignals.loadGame, () => { this.OnLoadGameButton(); });
        }

        public void OnLoadGameButton()
        {
            //TODO: load what? doesnt make sense here, remove
            //either make a load list in the in game option menu or go back to startscreen and load a specific game

            //SaveLoadGameManager.Load();
        }

        public void OnSaveGameButton()
        {
            SaveLoadGameManager.currentGame = new SaveGame(container);
            SaveLoadGameManager.Save();
        }

    }
}