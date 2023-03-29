using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{   //Handles shop logic - There can be unilimted ammounts of shops, each will keep its Own stock
    public delegate void Notify();  // delegate
    public event Notify StockChanged; // event
    public ItemListType AvailableItems;
    public ShopStockScriptableObject shopStockScriptableObject;

    public void Awake()
    {
        foreach(Item item in shopStockScriptableObject.itemStock)
        {
            AvailableItems.itemList.Add(item);
        }
    }
    public void UpdateStock(List<Item> newAvailableItems)
    {   //Changes stock
      
        OnStockChanged();
    }
    public void OnStockChanged()
    {   //Triggers this function when the stocks change
       
        StockChanged?.Invoke();
    }

}
