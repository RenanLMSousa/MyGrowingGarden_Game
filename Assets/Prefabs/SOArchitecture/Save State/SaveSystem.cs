using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveSystem 
{
    public static void SaveState(Player player, double timeOnClose, List<PlantingSpot> ownedPlantingSpots)
    {
        SaveState saveState = new SaveState(player, timeOnClose, PlantingSpotManager.ownedPlantingSpots);
        string saveString = JsonUtility.ToJson(saveState);
        File.WriteAllText(Application.dataPath + "/save.txt", saveString);
        Debug.Log("File saved in + "+  Application.dataPath + "/save.txt");

       
    }

    public static SaveState LoadState() 
    {   if(File.Exists(Application.dataPath + "/save.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
            SaveState saveState = JsonUtility.FromJson<SaveState>(saveString);
            return saveState;

        }
        else
        {
            Debug.LogWarning("File does not exist");
        }
        return null;
    }


}
