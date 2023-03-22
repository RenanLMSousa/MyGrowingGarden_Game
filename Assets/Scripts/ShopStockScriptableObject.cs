using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stock", menuName = "ScriptableObjects/New Stock", order = 1)]
public class ShopStockScriptableObject : ScriptableObject
{

    public List<Vase> vaseStock;
    public List<Crop> cropStock;
}
