using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class UIShopVaseGridElement : UIShopGridElement , IPointerClickHandler
{
    public override void DisplayItem(Item item)
    {
        this.item = item;
        itemScriptableObject = (VaseScriptableObject)item.ItemScriptableObject;
        setItemImage();
        setTxtBuyingPrice();
        setTxtName();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.LogWarning("Direct player reference");

        //Change sometime in the future
        buyer.BuyItem(item, 1);


    }
}
