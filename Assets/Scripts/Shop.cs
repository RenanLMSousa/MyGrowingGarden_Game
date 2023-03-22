using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shop:MonoBehaviour
{
    public  const int shopSize = 8;
    public ShopStockScriptableObject shopStockScriptableObject;
    public static IItem[] AvailableCrops = new IItem[shopSize];

    public void Awake()
    {
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
            AvailableCrops[i] = shopStockScriptableObject.cropStock[0];
        }
    }

}
