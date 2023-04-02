using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class UIShopGridElement : MonoBehaviour
{   //Gets atatched to the Shop Grid Element, and is responsible for changing it's layout when needed
    public TMP_Text txtBuyingPrice;
    public TMP_Text txtName;
    public Image itemImage;
    public Item item;
    public Player buyer;



    [HideInInspector]
    public ItemScriptableObject itemScriptableObject;

    public abstract void DisplayItem(Item item);
    public  void setItemImage()
    {
        this.itemImage.sprite = item.GetSprite();
    }

    public  void setTxtBuyingPrice()
    {
        txtBuyingPrice.text = item.GetBuyingPrice().ToString();
    }

    public  void setTxtName()
    {
        txtName.text = item.GetName();
    }



}
