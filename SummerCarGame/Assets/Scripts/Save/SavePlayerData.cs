using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SavePlayerData
{
    /// <summary>
    /// Puts the current player data in a serialized form into a binary file in a persistent data path
    /// </summary>
    public static void SavePlayer()
    {
        BinaryFormatter binary = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData playerData = GameDataManager.playerData;
        binary.Serialize(stream, playerData);
        stream.Close();
        Debug.Log($"Saved player data to {path}");
    }

    /// <summary>
    /// Loads the current player data from the binary file at the persistent data path
    /// </summary>
    public static void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.data";
        if (File.Exists(path)) // this is pretty much just for checking my data is OK, but good check for valid data
        {

            BinaryFormatter binary = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            try
            {
                PlayerData playerData = binary.Deserialize(stream) as PlayerData;
                stream.Close();
                Debug.Log($"Read in file from {path}");
                //Debug.Log(playerData.nextSpinDate[0] + " " + playerData.nextSpinDate[1] + " " + playerData.nextSpinDate[2]);
                GameDataManager.playerData = playerData;
            }
            catch (System.Exception exception)
            {
                Debug.Log($"Invalid player data\n{exception}");
            }
        }
        else
        {
            Debug.Log($"File did not exist at {path}");
        }
    }
}
