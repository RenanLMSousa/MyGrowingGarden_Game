using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnVaseCardClick : MonoBehaviour , IPointerClickHandler
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
        if(PlantingSpotManager.currentPlantingSpot.crop.cropScriptableObject != null)
        {
            GeneralSoundManager.generalSoundManager.PlaySFXCantBuyItem();
            Debug.LogWarning("Direct Sound Reference");
            return;
        }

        if (PlantingSpotManager.currentPlantingSpot.vase.vaseScriptableObject != null)
        {
            Item oldItem = new Item(PlantingSpotManager.currentPlantingSpot.vase.vaseScriptableObject);
            this.inventory.AddToInventory(oldItem, 1);
        }


        GeneralSoundManager.generalSoundManager.PlaySFXPutVase();
        Debug.LogWarning("Direct Sound Reference");

        PlantingSpotManager.currentPlantingSpot.setVase((VaseScriptableObject)item.ItemScriptableObject);
        this.inventory.RemoveFromInventory(item, 1);
        this.gameObject.transform.parent.parent.gameObject.SetActive(false);
        onClickEvent.Raise();
        
    }
}
