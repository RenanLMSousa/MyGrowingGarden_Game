using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop
{   //Handles shop logic - There can be unilimted ammounts of shops, each will keep its Own stock
    public delegate void Notify();  // delegate
    public event Notify StockChanged; // event
    public  List<Item> AvailableItems = new List<Item>();


    public Shop(List<Item> AvailableItems)
    {
        this.AvailableItems = AvailableItems;
    }
    public void BuyItem(Item item,IBuyer buyer, int ammount = 1)
    {
        if (buyer.CanBuy(item.GetSellingPrice() * ammount))
        {
            buyer.BuyItem(item, ammount);
        }
    }
    public void UpdateStock(List<Item> newAvailableItems)
    {   //Changes stock
        this.AvailableItems = newAvailableItems;
        OnStockChanged();
    }
    public void OnStockChanged()
    {   //Triggers this function when the stocks change
       
        StockChanged?.Invoke();
    }

}
