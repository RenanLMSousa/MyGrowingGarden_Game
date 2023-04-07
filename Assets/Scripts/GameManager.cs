using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public static GameManager gameManager;
    [Header("Save state objects")]
    public PlantingSpot plantingSpotPrefab;
    public GameObject UIInteracteableAreaPrefab;
    public Transform UIInteracteableAreaPrefabParent;

    
    private void Awake()
    {
        Application.targetFrameRate = 61;
        PlantingSpotManager.player = this.player;
        gameManager = this;
    }

    private void Start()
    {
        LoadState();
    }
    public void SaveState()
    {

        TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
        double unixVersion = (double)timeSpan.TotalSeconds;

        SaveSystem.SaveState(player,unixVersion,PlantingSpotManager.ownedPlantingSpots);
    }
    public void LoadState()
    {
        
        SaveState saveState = SaveSystem.LoadState();
        if(saveState == null) { return; }


        TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
        double currentTime = (double)timeSpan.TotalSeconds;
        double timePassed = currentTime  - saveState.timeOnClose;
        player.playerName = saveState.playerName;
        Debug.Log(timePassed.ToString() + "seconds passed!");
        player.SetMoney(saveState.playerMoney);
        for(int i = 0; i < saveState.plantingSpotsOwned; i++)
        {
            
            PlantingSpot plantingSpot = PlantingSpotManager.InstantiatePlantingSpotWithUI(plantingSpotPrefab,UIInteracteableAreaPrefab,UIInteracteableAreaPrefabParent);
            VaseScriptableObject vaseSO = Resources.Load(saveState.vasesOnPlantingSpots[i]) as VaseScriptableObject;
            plantingSpot.setVase(vaseSO);

            CropScriptableObject cropSO = Resources.Load(saveState.cropsOnPlantingSpots[i]) as CropScriptableObject;
            plantingSpot.setCrop(cropSO);
            plantingSpot.crop.SetGrowingTime((float)(plantingSpot.crop.GetGrowingTime() + timePassed));
        }

        for(int i =0; i < saveState.inventoryItem.Count; i++)
        {
            ItemScriptableObject itemSo = Resources.Load(saveState.inventoryItem[i]) as ItemScriptableObject;
            Item item = new Item(itemSo);
            int ammount = saveState.inventoryAmmount[i];
            player.inventory.AddToInventory(item, ammount);
        }

    }
    private void OnApplicationQuit()
    {
        SaveState();
    }
}
