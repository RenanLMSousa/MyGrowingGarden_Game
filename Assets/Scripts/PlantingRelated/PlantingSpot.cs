using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlantingSpot : MonoBehaviour
{   //Represents the Crop and vase relation, there can be a vase without a crop but not the opposite
    public Crop crop;
    public Vase vase;
    public Shelf shelf;


    public void setCrop(CropScriptableObject cropSO) {

        crop.SetCrop(cropSO);
        if (vase != null)
        {
            crop.SetIsPlanted(true);
            crop.SetGrowthTime(crop.GetGrowthTime() / vase.GetGrowthAcceleration());
            crop.SetSellingValue(crop.GetSellingValue() * vase.GetProductionMultiplier());

        }

    }
    public void setVase(VaseScriptableObject vaseSO)
    {
        vase.SetVase(vaseSO);
    }

    public void setShelf(Shelf shelf)
    {
        
        this.shelf = shelf;

    }



}