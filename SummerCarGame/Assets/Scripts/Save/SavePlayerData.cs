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
        StoredPlayerData playerData = new StoredPlayerData(GameDataManager.playerData);
        binary.Serialize(stream, playerData);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.data";
        Debug.Log(path);
        StreamReader streamReader = new StreamReader(path);
        Debug.Log(streamReader.ReadToEnd());
        streamReader.Close();

        if (File.Exists(path))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            StoredPlayerData playerData = binary.Deserialize(stream) as StoredPlayerData;
            stream.Close();
            return new PlayerData(playerData);
        }
        else
        {
            return new PlayerData();
        }
    }
}
