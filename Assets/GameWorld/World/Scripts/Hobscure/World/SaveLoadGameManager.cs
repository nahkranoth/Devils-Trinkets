using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;
using Hobscure.World;

namespace Hobscure.Main
{
    public static class SaveLoadGameManager {

        public static SaveGame currentGame;

        public static List<SaveGame> saveGames = new List<SaveGame>();

        public static void Save()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/savegames.gd");
            Debug.Log(Application.persistentDataPath);
            saveGames.Add(currentGame);
            bf.Serialize(file, saveGames);
            file.Close();
        }

        public static List<SaveGame> LoadList()
        {
            if (File.Exists(Application.persistentDataPath + "/savegames.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/savegames.gd", FileMode.Open);

                saveGames = (List<SaveGame>)bf.Deserialize(file);
                file.Close();
                return saveGames;

            }
            return null;
        }
    }
}
