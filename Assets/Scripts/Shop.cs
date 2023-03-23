using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop
{
    public delegate void Notify();  // delegate
    public event Notify StockChanged; // event
    public  const int shopSize = 8;
    public ShopStockScriptableObject shopStockScriptableObject;
    public  IItem[] AvailableItems = new IItem[shopSize];


    public Shop(ShopStockScriptableObject shopStockScriptableObject)
    {
        this.shopStockScriptableObject = shopStockScriptableObject;
        ChangeStock();
    }
    public  void BuyItem(IItem item,IBuyer buyer, int ammount = 1)
    {
        if (buyer.CanBuy(item.GetSellingPrice() * ammount))
        {
            buyer.BuyItem(item, ammount);
        }
    }
    public void ChangeStock()
    {
        for(int i = 0; i < shopSize; i++)
        {
            int randomItem = UnityEngine.Random.Range(0,shopStockScriptableObject.itemStock.Count);
            AvailableItems[i] = (IItem)shopStockScriptableObject.itemStock[randomItem];
            
        }
        OnStockChanged();
    }
    public void OnStockChanged()
    {
       
        StockChanged?.Invoke();
    }

}
