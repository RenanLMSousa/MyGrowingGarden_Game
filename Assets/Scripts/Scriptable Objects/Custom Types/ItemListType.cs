using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item List Type", menuName = "ScriptableObjects/Item List Type", order = 1)]
public class ItemListType : ScriptableObject
{
    [HideInInspector]
    public List<Item> itemList = new List<Item>();

 
  
}
