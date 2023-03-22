using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IBuyer
{

    public void BuyItem(IItem item, int ammount)
    {
        Debug.Log(ammount.ToString() + item + "bought!");
    }

    public bool CanBuy(float price)
    {
        throw new System.NotImplementedException();
    }

    public float GetMoney()
    {
        throw new System.NotImplementedException();
    }

    public void SellItem(IItem item, int ammount)
    {
        throw new System.NotImplementedException();
    }

    public void SetMoney(float money)
    {
        throw new System.NotImplementedException();
    }
}
