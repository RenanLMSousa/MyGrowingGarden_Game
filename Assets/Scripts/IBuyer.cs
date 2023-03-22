using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuyer 
{

    public void BuyItem(IItem item, int ammount);
    public void SellItem(IItem item,int ammount);
    public bool CanBuy(float price);
    public float GetMoney();
    public void SetMoney(float money);
}
