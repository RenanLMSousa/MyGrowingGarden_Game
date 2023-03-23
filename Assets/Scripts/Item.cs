using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour, IItem
{
    public abstract float GetBuyingPrice();
    public abstract string GetName();
    public abstract float GetSellingPrice();
    public abstract Sprite GetSprite();
    public abstract void SetBuyingPrice(float buyingPrice);
    public abstract void SetSellingPrice(float sellingPrice);
}
