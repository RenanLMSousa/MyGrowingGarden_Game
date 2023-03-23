using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IItem
{
    public string GetName();
    public float GetBuyingPrice();
    public float GetSellingPrice();
    public void SetBuyingPrice(float buyingPrice);
    public void SetSellingPrice(float sellingPrice);

    public Sprite GetSprite();

}
