using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SavePlayerData
{
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
