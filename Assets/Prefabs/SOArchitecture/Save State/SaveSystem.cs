using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveSystem 
{
    private static readonly string path  = Application.persistentDataPath + "\\MyGGSave.txt";
    public static void SaveState(Player player, double timeOnClose, List<PlantingSpot> ownedPlantingSpots)
    {
        

        SaveState saveState = new SaveState(player, timeOnClose, PlantingSpotManager.ownedPlantingSpots);
        string saveString = JsonUtility.ToJson(saveState);

        Debug.Log("Save money!" + player.money.floatValue);
        Debug.Log("Save spots!!" + ownedPlantingSpots.Count);
        File.WriteAllText(path, saveString);
        Debug.Log("File saved in + "+ path);

       
    }

    public static SaveState LoadState() 
    {
        

         if (File.Exists(path))
         {
             string saveString = File.ReadAllText(path);
             SaveState saveState = JsonUtility.FromJson<SaveState>(saveString);
             return saveState;

         }
         else
         {
               
             Debug.LogWarning("File does not exist");
             return null;
         }
    }


}
