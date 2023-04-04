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
            if (PlantingSpotManager.currentPlantingSpot.crop.cropScriptableObject != null)
            {
                Item oldItem = new Item(PlantingSpotManager.currentPlantingSpot.crop.cropScriptableObject);
                this.inventory.AddToInventory(oldItem, 1);
            }

            PlantingSpotManager.currentPlantingSpot.setCrop((CropScriptableObject)item.ItemScriptableObject);
            this.inventory.RemoveFromInventory(item, 1);
            onClickEvent.Raise();
        }
    }
}
