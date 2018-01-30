using UnityEngine;
using UnityEngine.SceneManagement;
using Hobscure.Main;

namespace Hobscure.StartScreen { 
    public class StartMenu : MonoBehaviour {

        [SerializeField]
        GameObject prefabSaveGameItem;

        [SerializeField]
        Transform saveGameListHolder;

        public void Awake()
        {
            var saveGameList = SaveLoadGameManager.LoadList();
            
            if (saveGameList != null)
            {
                for (int i = 0; i < saveGameList.Count; i++)
                {
                    var saveGame = saveGameList[i];
                    var saveGameItem = Instantiate(prefabSaveGameItem);
                    saveGameItem.transform.SetParent(saveGameListHolder, false);
                    saveGameItem.GetComponent<SaveGameItem>().SetSaveGame(saveGame);
                }
            }

        }

        public  void OnStartButton()
        {
            //start Game
            SceneManager.LoadScene("GameWorld");
        }

    }
}