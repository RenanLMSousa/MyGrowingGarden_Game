using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemScriptableObject : ScriptableObject
{

    public float buyingPrice;
    public float sellingPrice;
    public int tier;
    public string description;
    public string itemName;

    public abstract Sprite GetItemSprite();
}
