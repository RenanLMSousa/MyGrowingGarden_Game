using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventoy Slot List Type", menuName = "ScriptableObjects/Inventory Slot List Type", order = 1)]
public class InventorySlotListType : ScriptableObject
{

    //[HideInInspector]
    public List<InventorySlot> list = new List<InventorySlot>();




}
