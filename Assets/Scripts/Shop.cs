using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shop
{
    private static List<IItem> AvailableCrops = new List<IItem>();
    public virtual void OnBoughtItem(IItem item,IBuyer buyer, int ammount = 1)
    {
        buyer.BuyItem(item, ammount);
    }
    public static void ChangeStock()
    {

    }

}
