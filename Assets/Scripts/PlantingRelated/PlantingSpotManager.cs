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

    private static float TODOGrowthBonus = 1;
    private static float TODOGrowthAcceleration = 1;

  
    public static void HarvestPlant(PlantingSpot plantingSpot)
    {
        if (!plantingSpot.crop.IsGrown()) return;
        player.SetMoney(player.GetMoney() + plantingSpot.crop.GetSellingValue()*GetOnHarvestTierDiffBonus(plantingSpot));
        plantingSpot.crop.SetNull();


    }

    private static float GetOnHarvestTierDiffBonus(PlantingSpot plantingSpot)
    {
        return GetOnHarvestTierDiffBonus(plantingSpot.crop.GetTier() , plantingSpot.vase.GetTier());
    }
    private static float GetOnHarvestTierDiffBonus(int crop, int vase)
    {   
        if(vase <= crop) { return 1; }
        const int BASEVALUE = 2;

        return Mathf.Pow(BASEVALUE, vase - crop);
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

            GeneralSoundManager.generalSoundManager.PlaySFXBuyNewArea();
            Debug.LogWarning("Direct Sound Reference");

            player.SetMoney(player.GetMoney() - GetNextSpotPrice());
            InstantiatePlantingSpotWithUI(plantingSpotPrefab, UIInteracteableAreaPrefab, UIInteracteableAreaPrefabParent);
            InstantiatePlantingSpotWithUI(plantingSpotPrefab, UIInteracteableAreaPrefab, UIInteracteableAreaPrefabParent);
        }
        else{

            GeneralSoundManager.generalSoundManager.PlaySFXCantBuyItem();
            Debug.LogWarning("Direct Sound Reference");

        }
    }
    public static float GetNextSpotPrice()
    {
        return BASEPRICE*Mathf.Pow(2,ownedPlantingSpots.Count);
    }

    public static void IncreaseGrowingTimeAbsolute(float increase)
    {
        foreach(PlantingSpot spot in ownedPlantingSpots)
        {
            spot.crop.SetGrowingTime(spot.crop.GetGrowingTime() + increase);
        }
    }
    public static void IncreaseGrowingTimeRelative(float increase)
    {
        foreach (PlantingSpot spot in ownedPlantingSpots)
        {
            spot.crop.SetGrowingTime(spot.crop.GetGrowingTime() + increase*spot.vase.GetGrowthAcceleration());
        }
    }
    public static void GrowCrop(PlantingSpot plantingSpot)
    {
        plantingSpot.crop.SetGrowingTime(plantingSpot.crop.GetGrowthTime());
    }
    public static void HarvestAll()
    {
        foreach(PlantingSpot plantingSpot in ownedPlantingSpots)
        {
            HarvestPlant(plantingSpot);
        }
    }
    public static void GrowAll()
    {
        foreach (PlantingSpot plantingSpot in ownedPlantingSpots)
        {
            GrowCrop(plantingSpot);
        }
    }

}
