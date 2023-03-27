using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item List Type", menuName = "ScriptableObjects/Item List Type", order = 1)]
public class ItemListType : ScriptableObject
{
    [SerializeField]
    private List<Item> _itemList;
    [HideInInspector]
    public List<Item> itemList = new List<Item>();

    private void OnEnable()
    {
        foreach(Item item in _itemList)
        {
            itemList.Add(item);
        }
    }
}
