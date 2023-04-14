using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarvestFunction : MonoBehaviour
{
    public void harvestAllPlants()
    {
        PlantingSpotManager.HarvestAll();
        GeneralSoundManager.generalSoundManager.PlaySFXHarvestCrop();
        Debug.LogWarning("Direct Sound Reference");
    }

    public void growAllPlants()
    {
        PlantingSpotManager.GrowAll();
        GeneralSoundManager.generalSoundManager.PlaySFXHarvestCrop();
        Debug.LogWarning("Direct Sound Reference");
    }
}
