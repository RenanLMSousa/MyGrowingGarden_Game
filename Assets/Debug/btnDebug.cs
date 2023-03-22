using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnDebug : MonoBehaviour
{

    public Vase vase;
    public Crop crop;
    // Start is called before the first frame update
    public void testPlantOnCrop()
    {
        Debug.Log("Plantou?");
        CropPlantingManager.PlantCropOnVase(new CropVasePair(crop, vase));
    }
    public void testRemoveFromCropVase()
    {
        Debug.Log("Removeu?");
        CropPlantingManager.RemoveCropFromVase(CropPlantingManager.GetCropVasePair(vase));
    }
    public void testRemoveFromCropCrop()
    {
        Debug.Log("Removeu?");
        CropPlantingManager.RemoveCropFromVase(CropPlantingManager.GetCropVasePair(crop));
    }
}
