using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stock", menuName = "ScriptableObjects/NewStock", order = 1)]
public class ShopStockScriptableObject : ScriptableObject
{
 
    [SerializeField]
    public List<Item> itemStock;


}
