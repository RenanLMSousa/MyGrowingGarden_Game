using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantingSpotManager : MonoBehaviour
{
    [HideInInspector]
    public static Player player;
    public static PlantingSpot currentPlantingSpot = null;
    [HideInInspector]
    public GameObject UIInteractiveArea;
    [SerializeField]
    private PlantingSpot plantingSpot;

    private void Awake()
    {
        player = GameManager.gameManager.player;
    }
    public static void HarvestPlant(PlantingSpot plantingSpot)
    {
        player.SetMoney(player.GetMoney() + plantingSpot.crop.GetSellingValue());
        plantingSpot.crop.SetNull();

        
    }

   



}
