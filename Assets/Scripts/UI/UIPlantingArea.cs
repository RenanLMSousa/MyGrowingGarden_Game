using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class UIPlantingArea : MonoBehaviour , IPointerClickHandler
{
    [HideInInspector]
    public PlantingSpot plantingSpot;
    public GameEvent onClick;
    public TMP_Text txtCountdown;



    public void OnPointerClick(PointerEventData eventData)
    {

       
        
        PlantingSpotManager.currentPlantingSpot = plantingSpot;
        if (plantingSpot.crop.IsGrown())
        {
        PlantingSpotManager.HarvestPlant(plantingSpot);

            GeneralSoundManager.generalSoundManager.PlaySFXHarvestCrop();
            Debug.LogWarning("Direct Sound Reference");



        }
        else { onClick.Raise(); }
            
        
    }
    private void Update()
    {

        
            if (plantingSpot.crop.cropScriptableObject != null)
            {
                txtCountdown.text = UnityConversor.secToDHMS(plantingSpot.crop.GetTimeLeft());
            }
            else
            {
                txtCountdown.text = "";
            }
        
    }
    public void SetPlantGrown()
    {

    }


}
