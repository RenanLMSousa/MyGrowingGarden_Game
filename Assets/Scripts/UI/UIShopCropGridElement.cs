using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class UIShopCropGridElement : UIShopGridElement, IPointerClickHandler
{
    public TMP_Text txtSellingPrice;
    public TMP_Text txtTime;
    
    public override void DisplayItem(Item item)
    { 
        this.item = item;
        itemScriptableObject = (CropScriptableObject)item.ItemScriptableObject;
        setItemImage();
        setTxtBuyingPrice();
        setTxtName();
        txtSellingPrice.text = ((CropScriptableObject)itemScriptableObject).sellingPrice.ToString() +" Seconds";
        txtTime.text = ((CropScriptableObject)itemScriptableObject).growthTime.ToString();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(this.item.GetName());
        //Change sometime in the future
        GameManager.gameManager.player.BuyItem(item, 1);
        
       
    }

}
