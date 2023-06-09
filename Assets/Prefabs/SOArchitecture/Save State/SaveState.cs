using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveState
{
    public float playerMoney;
    public string playerName;

    public double timeOnClose;

    public List<string> vasesOnPlantingSpots;
    public List<string> cropsOnPlantingSpots;
    public List<double> cropsGrowthTime;

    public List<string> inventoryItem;
    public List<int> inventoryAmmount;


    public SaveState(Player player, double timeOnClose,List<PlantingSpot> ownedPlantingSpots)
    {
        this.playerName = player.playerName;
        this.playerMoney = player.GetMoney();
        this.timeOnClose = timeOnClose;

        vasesOnPlantingSpots = new List<string>();
        cropsOnPlantingSpots = new List<string>();
        cropsGrowthTime = new List<double>();
        inventoryItem = new List<string>();
        inventoryAmmount = new List<int>();

        foreach (PlantingSpot plantingSpot in ownedPlantingSpots)
        {
            vasesOnPlantingSpots.Add(plantingSpot.vase.GetSOName());
            cropsOnPlantingSpots.Add(plantingSpot.crop.GetSOName());
            cropsGrowthTime.Add(plantingSpot.crop.GetGrowingTime());
            
        }
        foreach (InventorySlot slot in player.inventory.inventorySlots.list)
        {
            inventoryItem.Add(slot.item.GetSOName());
            inventoryAmmount.Add(slot.ammount);
        }
    }

}
