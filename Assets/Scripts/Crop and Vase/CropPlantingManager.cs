using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CropVasePair
{
    public Crop crop;
    public Vase vase;

    public CropVasePair(Crop crop= null, Vase vase = null)
    {
        this.crop = crop;
        this.vase = vase;
    }

}
public class CropPlantingManager 
{

    public static List<CropVasePair> ownedSpots = new List<CropVasePair>();
    // Start is called before the first frame update


    public static void PlantCropOnVase(CropVasePair plantVase) {
        ownedSpots.Add(plantVase);
        plantVase.crop.transform.position = plantVase.vase.GetVaseTop();
        plantVase.crop.SetIsPlanted(true);
        plantVase.vase.SetIsPlantedOn(true);
    }

    public static void RemoveCropFromVase(CropVasePair plantVase)
    {

        ownedSpots.Remove(plantVase);
        MonoBehaviour.Destroy(plantVase.crop.gameObject);
        plantVase.crop.SetIsPlanted(false);
        plantVase.vase.SetIsPlantedOn(false);
    }

    public static CropVasePair GetCropVasePair(Crop crop)
    {
        foreach(CropVasePair pair in ownedSpots)
        {
            if(pair.crop == crop) { return pair; }
        }
        return null;
    }
    public static CropVasePair GetCropVasePair(Vase vase)
    {
        foreach (CropVasePair pair in ownedSpots)
        {
            if (pair.vase == vase) { return pair; }
        }
        return null;
    }

}
