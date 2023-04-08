using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShelfManager : MonoBehaviour
{

    public Card vaseCard;
    public Card cropCard;
    public GameObject parentObject;
    // Start is called before the first frame update

    public void UpdateCards()
    {
        CropScriptableObject cropSo = PlantingSpotManager.currentPlantingSpot.crop.cropScriptableObject;
        VaseScriptableObject vaseSO = PlantingSpotManager.currentPlantingSpot.vase.vaseScriptableObject;
        Item vaseItem = null;
        Item cropItem = null;

        if (vaseSO != null)
            vaseItem = new Item(vaseSO);
        if (cropSo != null)
            cropItem = new Item(cropSo);

        vaseCard.SetItem(vaseItem);
        cropCard.SetItem(cropItem);
    }
    public void OnOpen()
    {   if (parentObject.activeSelf == false)
        {
            Debug.LogWarning("Direct Sound Reference");
            GeneralSoundManager.generalSoundManager.PlaySFXOpenUI();
        }
        parentObject.SetActive(true);
        UpdateCards();

    }
}
