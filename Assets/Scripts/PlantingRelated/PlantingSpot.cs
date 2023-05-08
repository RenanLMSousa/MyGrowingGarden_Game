using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlantingSpot : MonoBehaviour ,IPointerClickHandler
{   //Represents the Crop and vase relation, there can be a vase without a crop but not the opposite
    public Crop crop;
    public Vase vase;
    public Shelf shelf;


    public void setCrop(CropScriptableObject cropSO) {

        crop.SetCrop(cropSO);
        
        if (vase != null)
        {
            
            if (crop.GetTier() > vase.GetTier()) { return; }


            crop.SetIsPlanted(true);
            crop.SetGrowthTime(crop.GetGrowthTime() / vase.GetGrowthAcceleration());
            crop.SetSellingValue(crop.GetSellingValue() * vase.GetProductionMultiplier());
            crop.transform.position = vase.GetVaseTop();
            

        }

    }
    public void setVase(VaseScriptableObject vaseSO)
    {   if(crop.cropScriptableObject != null) { return; }
        vase.SetVase(vaseSO);
    }

    public void setShelf(Shelf shelf)
    {
        
        this.shelf = shelf;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("@");
    }
}