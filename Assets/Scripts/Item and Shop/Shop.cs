using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop
{
    public delegate void Notify();  // delegate
    public event Notify StockChanged; // event
    public  List<Item> AvailableItems = new List<Item>();


    public Shop(List<Item> AvailableItems)
    {
        this.AvailableItems = AvailableItems;
        UpdateStock();
    }
    public void BuyItem(Item item,IBuyer buyer, int ammount = 1)
    {
        if (buyer.CanBuy(item.GetSellingPrice() * ammount))
        {
            buyer.BuyItem(item, ammount);
        }
    }
    public void UpdateStock()
    {
        OnStockChanged();
    }
    public void OnStockChanged()
    {
       
        StockChanged?.Invoke();
    }

}
