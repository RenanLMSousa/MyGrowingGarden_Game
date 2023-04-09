using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    int tier = 0;
    float buyingPrice = 0;
    float sellingPrice = 0;
    string name;
    Sprite sprite;
    string description;
    public ItemScriptableObject ItemScriptableObject;

    public Item(ItemScriptableObject itemScriptableObject) {
        this.ItemScriptableObject = itemScriptableObject;
        this.buyingPrice = itemScriptableObject.buyingPrice;
        this.sellingPrice = itemScriptableObject.sellingPrice;
        this.name = itemScriptableObject.itemName;
        this.sprite = itemScriptableObject.GetItemSprite();
        this.tier = itemScriptableObject.tier;
        this.description = itemScriptableObject.description;
            }
    public float GetBuyingPrice()
    {
        return this.buyingPrice;
    }

    public string GetName()
    {
        return this.name;
    }
    public Sprite GetSprite()
    {
        return this.sprite;
    }
    public int GetTier()
    {
        return this.tier;
    }
    public string GetSOName()
    {
        return ItemScriptableObject == null? null : ItemScriptableObject.name;
    }
    public string GetDesc()
    {
        return ItemScriptableObject == null ? null : ItemScriptableObject.description;
    }
    /*
        public float GetSellingPrice()
    {
        return this.sellingPrice;
    }
    
    public void SetBuyingPrice(float buyingPrice)
    {
        this.buyingPrice = buyingPrice;
    }

    public void SetSellingPrice(float sellingPrice)
    {
        this.sellingPrice = sellingPrice;
    }*/
}
