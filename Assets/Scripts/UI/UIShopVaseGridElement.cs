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
        Debug.Log(this.item.GetName());

        //Change sometime in the future
        GameManager.gameManager.player.BuyItem(item, 1);


    }
}
