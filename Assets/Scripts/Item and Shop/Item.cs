using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    float buyingPrice = 0;
    float sellingPrice = 0;
    string name;
    Sprite sprite;


    public Item(ItemScriptableObject itemScriptableObject) {
        this.buyingPrice = itemScriptableObject.buyingPrice;
        this.sellingPrice = itemScriptableObject.sellingPrice;
        this.name = itemScriptableObject.name;
        this.sprite = itemScriptableObject.GetItemSprite();
        
            }
    public float GetBuyingPrice()
    {
        throw new System.NotImplementedException();
    }

    public string GetName()
    {
        return this.name;
    }

    public float GetSellingPrice()
    {
        throw new System.NotImplementedException();
    }

    public Sprite GetSprite()
    {
        return this.sprite;
    }

    public void SetBuyingPrice(float buyingPrice)
    {
        throw new System.NotImplementedException();
    }

    public void SetSellingPrice(float sellingPrice)
    {
        throw new System.NotImplementedException();
    }
}
