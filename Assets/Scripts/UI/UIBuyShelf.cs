using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class UIBuyShelf : MonoBehaviour , IPointerClickHandler
{
    public PlantingSpot PlantingSpotPrefab;
    public GameObject UIInteracteableAreaPrefab;
    public Vector3 startPos;

    public TMP_Text txtPrice;

    private void Awake()
    {
        startPos = this.transform.position;

    }

    public void OnPointerClick(PointerEventData eventData)
    {

        PlantingSpotManager.BuySpot(PlantingSpotPrefab, UIInteracteableAreaPrefab, this.transform.parent);



    }

    public void Update()
    {
        this.txtPrice.text = UnityConversor.moneyToK(PlantingSpotManager.GetNextSpotPrice());
        this.transform.position = startPos + (PlantingSpotManager.ownedPlantingSpots.Count/2) * PlantingSpotManager.yDistance* new Vector3(0,1,0);
    }


}
