using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public static void SavePlayer(Player player)
    {
        PlayerData data = new PlayerData();

        // Save position
        data.position = new float[3];
        data.position[0] = player.transform.position.x;
        data.position[1] = player.transform.position.y;
        data.position[2] = player.transform.position.z;

        // Save inventory (by item name or ID)
        data.inventoryItems = player.inventory.GetItemNames();

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/save.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.LogWarning("No save file found.");
            return null;
        }
    }
}