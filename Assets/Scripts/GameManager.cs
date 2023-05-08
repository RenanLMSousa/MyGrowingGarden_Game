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

    private float _timeSinceUpdate = 0;


    private double _TimeOnQuit = 0;
    private double _TimeOnComeback = 0;

    public GameObject selectNickname;
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

    private void Update()
    {
        PassiveMoneyGain();
    }

    private void PassiveMoneyGain()
    {
        _timeSinceUpdate += Time.deltaTime;
        if (_timeSinceUpdate >= 1)
        {   //+0.5 gold/s each planting spot
            const float BASEVALUE = 2.5f;
            int ownedLines = PlantingSpotManager.ownedPlantingSpots.Count/2;
            float bonus =  Mathf.Pow(BASEVALUE, ownedLines)* ownedLines;
            player.money.floatValue += Mathf.Pow(1.5f, PlantingSpotManager.ownedPlantingSpots.Count/2);
            _timeSinceUpdate = 0;
        }

    }
    private void OnApplicationPause(bool pause)
    { 

        if (pause)
        {   
            //Save the game state the pause time
            SaveState();

            TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
            _TimeOnQuit = (double)timeSpan.TotalSeconds;
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            //Increase the crop growing time
            TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
            _TimeOnComeback = (double)timeSpan.TotalSeconds;

            double TimeDiff = _TimeOnComeback - _TimeOnQuit;
            PlantingSpotManager.IncreaseGrowingTimeAbsolute((float)(TimeDiff));
        }
    }
    public void SaveState()
    {   //It won't save when the scene is loading because there are 0 spots
        if(PlantingSpotManager.ownedPlantingSpots.Count  == 0) {
            Debug.LogWarning("Invalid saving attempt revoked");
            return; }
        TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
        double unixVersion = (double)timeSpan.TotalSeconds;

        SaveSystem.SaveState(player,unixVersion,PlantingSpotManager.ownedPlantingSpots);
    }
    public void LoadState()
    {
        
        SaveState saveState = SaveSystem.LoadState();

        //Verifies if there is a save archive, if there is , it reinforces checking if it is a valid state
        if (saveState == null || saveState.vasesOnPlantingSpots.Count == 0 || saveState.cropsOnPlantingSpots.Count == 0)
        {
            LoadNewState();
            Debug.Log("No save state!");
            return;
        }
        else
        {
            LoadSavedState(saveState);
        }
       


    }
    private void LoadNewState()
    {   /*Create a new state
         2 planting spots
         100 money
         No player name
         
         */
        selectNickname.SetActive(true);

        PlantingSpotManager.InstantiatePlantingSpotWithUI(plantingSpotPrefab, UIInteracteableAreaPrefab, UIInteracteableAreaPrefabParent);
        PlantingSpotManager.InstantiatePlantingSpotWithUI(plantingSpotPrefab, UIInteracteableAreaPrefab, UIInteracteableAreaPrefabParent);

        player.playerName = "New player";
        player.SetMoney(100);
        SaveState();
    }
    private void LoadSavedState(SaveState saveState)
    {   //Reads the saveState and converts it to in game data
        
        TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
        double currentTime = (double)timeSpan.TotalSeconds;
        double timePassed = currentTime - saveState.timeOnClose;
        player.playerName = saveState.playerName;
        Debug.Log(timePassed.ToString() + "seconds passed!");
        player.SetMoney(saveState.playerMoney);
        for (int i = 0; i < saveState.vasesOnPlantingSpots.Count; i++)
        {

            PlantingSpot plantingSpot = PlantingSpotManager.InstantiatePlantingSpotWithUI(plantingSpotPrefab, UIInteracteableAreaPrefab, UIInteracteableAreaPrefabParent);

            VaseScriptableObject vaseSO = Resources.Load( saveState.vasesOnPlantingSpots[i]) as VaseScriptableObject;
            plantingSpot.setVase(vaseSO);

            CropScriptableObject cropSO = Resources.Load( saveState.cropsOnPlantingSpots[i]) as CropScriptableObject;
            plantingSpot.setCrop(cropSO);
            plantingSpot.crop.SetGrowingTime((float)(saveState.cropsGrowthTime[i] + timePassed));
        }

        for (int i = 0; i < saveState.inventoryItem.Count; i++)
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


    public void ClearPlantingSpots()
    {

        Debug.Log(PlantingSpotManager.ownedPlantingSpots.Count);
        Debug.Log(PlantingSpotManager.ownedPlantingSpots);
        Debug.Log(PlantingSpotManager.player);
        Debug.Log(PlantingSpotManager.currentPlantingSpot);

        foreach (PlantingSpot ps in PlantingSpotManager.ownedPlantingSpots)
        {
            Debug.Log(ps);
            Debug.Log(ps.crop);
            Debug.Log(ps.vase);
        }
    }
}
