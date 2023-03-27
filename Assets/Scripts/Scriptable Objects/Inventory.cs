using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot
{
    public Item item;
    public int ammount;

    public InventorySlot(Item item, int ammount)
    {
        this.item = item;
        this.ammount = ammount;
    }
}
[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory", order = 1)]
public class Inventory : ScriptableObject, IInventory
{

    public List<InventorySlot> inventorySlots;
    public void AddToInventory(Item item, int ammount)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveFromInventory(Item item, int ammount)
    {
        throw new System.NotImplementedException();
    }
}
