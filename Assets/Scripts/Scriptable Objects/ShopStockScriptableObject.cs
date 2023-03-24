using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stock", menuName = "ScriptableObjects/NewStock", order = 1)]
public class ShopStockScriptableObject : ScriptableObject
{
 
    [SerializeField]
    private List<ItemScriptableObject> _itemStock;


    public List<Item> itemStock = new List<Item>();

    private void OnEnable()
    {
        try{
            foreach (ItemScriptableObject itemSO in _itemStock)
            {
                itemStock.Add(new Item(itemSO));
            }

        }
        catch
        {
            Debug.Log("Empty Stock");
        }
    }



}
