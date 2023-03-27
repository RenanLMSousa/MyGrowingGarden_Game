using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopVaseGridElement : UIShopGridElement
{
    public override void DisplayItem(Item item)
    {
        this.item = item;
        itemScriptableObject = (VaseScriptableObject)item.ItemScriptableObject;
        setItemImage();
        setTxtBuyingPrice();
        setTxtName();
    }
}
