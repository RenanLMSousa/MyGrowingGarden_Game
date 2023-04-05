using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIBuyShelf : MonoBehaviour , IPointerClickHandler
{
    public PlantingSpot PlantingSpotPrefab;
    public GameObject UIInteracteableAreaPrefab;
    public Vector3 startPos;

    private void Awake()
    {
        startPos = this.transform.position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        InstantiatePrefab();
        InstantiatePrefab();
       


    }

    public void Update()
    {
        this.transform.position = startPos + (PlantingSpotManager.ownedPlantingSpots.Count/2) * PlantingSpotManager.yDistance* new Vector3(0,1,0);
    }

    public void InstantiatePrefab() {


        PlantingSpotManager.InstantiatePlantingSpotWithUI( PlantingSpotPrefab,UIInteracteableAreaPrefab, this.transform.parent);
      
    }

}
