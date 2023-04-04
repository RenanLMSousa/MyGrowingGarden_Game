using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player", order = 1)]
public class Player : ScriptableObject, IBuyer
{
    public string playerName;
    public Inventory inventory;
    public FloatType money;
    public void BuyItem(Item item, int ammount)
    {
        if (!CanBuy(item.GetBuyingPrice()*ammount)) return;
        this.money.floatValue -= item.GetBuyingPrice() * ammount;
        inventory.AddToInventory(item, ammount);
    }

    public bool CanBuy(float price)
    {
        return (this.money.floatValue - price) >= 0;
    }

    public float GetMoney()
    {
        return money.floatValue;
    }

    public void SellItem(Item item, int ammount)
    {
        throw new System.NotImplementedException();
    }

    public void SetMoney(float money)
    {
        this.money.floatValue = money;
    }
    public void DropItem(Item item, int ammount)
    {
        inventory.RemoveFromInventory(item, ammount);
    }
}
