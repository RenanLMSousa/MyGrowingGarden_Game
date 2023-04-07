using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantingSpotManager : MonoBehaviour
{
    [HideInInspector]
    public static Player player;
    public static PlantingSpot currentPlantingSpot = null;
    public static List<PlantingSpot> ownedPlantingSpots = new List<PlantingSpot>();
    [HideInInspector]
    public GameObject UIInteractiveArea;
    [SerializeField]
    private PlantingSpot plantingSpot;

    public static float xDistance = 1.5f;
    public static float yDistance = 4f;
    private static float startingX = 0;
    private static float startingY = 0;


    private static float BASEPRICE = 100;

  
    public static void HarvestPlant(PlantingSpot plantingSpot)
    {
        player.SetMoney(player.GetMoney() + plantingSpot.crop.GetSellingValue());
        plantingSpot.crop.SetNull();

        
    }
    public static void AddPlantingSpot(PlantingSpot plantingSpot)
    {
        ownedPlantingSpots.Add(plantingSpot);
        
    }
    private Player GetPlayer()
    {
        return GameManager.gameManager.player;
    }
    public static PlantingSpot InstantiatePlantingSpot(PlantingSpot plantingSpotPrefab)
    {

        PlantingSpot _shelf = Instantiate(plantingSpotPrefab);
        float y = startingY + (int)(ownedPlantingSpots.Count/2)*yDistance;
        float x = (int)(ownedPlantingSpots.Count%2) == 0 ? startingX - xDistance : startingX + xDistance;
        _shelf.transform.position = new Vector2(x,y);
        PlantingSpotManager.AddPlantingSpot(_shelf);

        return _shelf;
    }
    public static PlantingSpot InstantiatePlantingSpotWithUI(PlantingSpot plantingSpotPrefab , GameObject UIInteracteableAreaPrefab , Transform UIInteracteableAreaPrefabParent)
    {
        PlantingSpot _shelf = PlantingSpotManager.InstantiatePlantingSpot(plantingSpotPrefab);


        GameObject _go = Instantiate(UIInteracteableAreaPrefab);
        _go.transform.position = _shelf.transform.position;

        _go.GetComponent<UIPlantingArea>().plantingSpot = _shelf.GetComponent<PlantingSpot>();

        _go.transform.SetParent(UIInteracteableAreaPrefabParent.transform);
        _shelf.GetComponent<PlantingSpotManager>().UIInteractiveArea = _go;
        return _shelf;

        
    }
    public static void BuySpot(PlantingSpot plantingSpotPrefab, GameObject UIInteracteableAreaPrefab, Transform UIInteracteableAreaPrefabParent)
    {

        if (GetNextSpotPrice() <= player.GetMoney())
        {
            player.SetMoney(player.GetMoney() - GetNextSpotPrice());
            InstantiatePlantingSpotWithUI(plantingSpotPrefab, UIInteracteableAreaPrefab, UIInteracteableAreaPrefabParent);
        }
    }
    public static float GetNextSpotPrice()
    {
        return BASEPRICE*ownedPlantingSpots.Count;
    }


}
