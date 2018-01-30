using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Hobscure.World;

namespace Hobscure.Main
{
    public class SaveGameItem : MonoBehaviour, IPointerClickHandler
    {

        public Text nameText;

        SaveGame saveGame;

        public void OnPointerClick(PointerEventData eventData)
        {
            SaveLoadGameManager.currentGame = saveGame;
            SceneManager.LoadScene("GameWorld");
        }

        public void SetSaveGame(SaveGame saveGame)
        {
            this.saveGame = saveGame;
        }

    }
}