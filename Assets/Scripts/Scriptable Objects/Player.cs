using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player", order = 1)]
public class Player : ScriptableObject, IBuyer
{
    public string playerName;
    public Inventory inventory;
    public float money;
    public void BuyItem(Item item, int ammount)
    {
        
        this.money -= item.GetBuyingPrice() * ammount;
        inventory.AddToInventory(item, ammount);
    }

    public bool CanBuy(float price)
    {
        throw new System.NotImplementedException();
    }

    public float GetMoney()
    {
        throw new System.NotImplementedException();
    }

    public void SellItem(Item item, int ammount)
    {
        throw new System.NotImplementedException();
    }

    public void SetMoney(float money)
    {
        throw new System.NotImplementedException();
    }
}
