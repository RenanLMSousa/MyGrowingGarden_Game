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

    private bool isGrown = false;

    public void OnPointerClick(PointerEventData eventData)
    {

       
        
        PlantingSpotManager.currentPlantingSpot = plantingSpot;
        if (plantingSpot.crop.IsGrown())
        {
        PlantingSpotManager.HarvestPlant(plantingSpot);

            GeneralSoundManager.generalSoundManager.PlaySFXHarvestCrop();
            Debug.LogWarning("Direct Sound Reference");
            isGrown = false;


        }
        else { onClick.Raise(); }
            
        
    }
    private string toTime(float timeInSecs) {

        float remaingTime = timeInSecs;
        int days = (int)(remaingTime / 86400);
        remaingTime  =  remaingTime %86400;

        int hours = (int)(timeInSecs / 3600);
        remaingTime = remaingTime % 3600;

        int minutes = (int)(timeInSecs / 60);
        remaingTime = remaingTime % 60;

        int seconds = (int)remaingTime;
        string DHMSFormatString = "";
        if (remaingTime == 0)
        {
            GeneralSoundManager.generalSoundManager.PlaySFXCropGrown();
            Debug.LogWarning("Direct Sound Reference and function overlap");

            isGrown = true;
            DHMSFormatString = "Fully Grown!";
            return DHMSFormatString;
        }

        if (days > 0) DHMSFormatString += days.ToString() + "D";
        if (hours > 0) DHMSFormatString += hours.ToString() + "H";
        if (minutes > 0) DHMSFormatString += minutes.ToString() + "M";
        if (seconds >=0) DHMSFormatString += seconds.ToString() + "s";


        return DHMSFormatString;

    }
    private void Update()
    {
        if (!isGrown)
        {
            if (plantingSpot.crop.cropScriptableObject != null)
            {
                txtCountdown.text = toTime(plantingSpot.crop.GetTimeLeft());
            }
            else
            {
                txtCountdown.text = "";
            }
        }
    }
    public void SetPlantGrown()
    {

    }


}
