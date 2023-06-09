using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnCropCardClick : MonoBehaviour , IPointerClickHandler
{
    Item item;

    [HideInInspector]
    public GameEvent onClickEvent;
    public Inventory inventory;
    public void Awake()
    {
        item = this.GetComponent<Card>().GetItem();
        this.inventory = GameManager.gameManager.player.inventory;
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        if (PlantingSpotManager.currentPlantingSpot.vase.vaseScriptableObject != null)
        {
            //Verifies the tier compatibility
            if(item.GetTier() > PlantingSpotManager.currentPlantingSpot.vase.GetTier())
            {
                GeneralSoundManager.generalSoundManager.PlaySFXCantBuyItem();
                Debug.LogWarning("Direct Sound Reference");
                return;

            }
            //Exchanges the crop on the vase with the one being clicked on (it sth is planted)
            if (PlantingSpotManager.currentPlantingSpot.crop.cropScriptableObject != null)
            {
                Item oldItem = new Item(PlantingSpotManager.currentPlantingSpot.crop.cropScriptableObject);
                this.inventory.AddToInventory(oldItem, 1);
            }

            GeneralSoundManager.generalSoundManager.PlaySFXPlantCrop();
            Debug.LogWarning("Direct Sound Reference");


            PlantingSpotManager.currentPlantingSpot.setCrop((CropScriptableObject)item.ItemScriptableObject);
            this.inventory.RemoveFromInventory(item, 1);

            //Closes other UI when crop is planted
            this.gameObject.transform.parent.parent.gameObject.SetActive(false);
            this.gameObject.transform.parent.parent.parent.gameObject.SetActive(false);
            onClickEvent.Raise();
            
        }
        else
        {
            GeneralSoundManager.generalSoundManager.PlaySFXCantBuyItem();
            Debug.LogWarning("Direct Sound Reference");
        }
    }
}
