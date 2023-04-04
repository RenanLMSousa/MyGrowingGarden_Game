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

    public InventorySlotListType inventorySlots;
    public void AddToInventory(Item item, int ammount)
    {
        for(int i = 0; i < inventorySlots.list.Count; i++)
        {
            if(inventorySlots.list[i].item.ItemScriptableObject == item.ItemScriptableObject)
            {
                inventorySlots.list[i].ammount += ammount;
                Debug.Log((inventorySlots.list[i].item.GetName(), inventorySlots.list[i].ammount));
                return;
            }
        }
        inventorySlots.list.Add(new InventorySlot(item, 1));
        foreach (InventorySlot slot in inventorySlots.list)
        {
            Debug.Log((slot.item.GetName(), slot.ammount));
        }
    }

    public void RemoveFromInventory(Item item, int ammount)
    {
        for (int i = 0; i < inventorySlots.list.Count; i++)
        {
            if (inventorySlots.list[i].item.ItemScriptableObject == item.ItemScriptableObject)
            {
                inventorySlots.list[i].ammount -= ammount;
                Debug.Log((inventorySlots.list[i].item.GetName(), inventorySlots.list[i].ammount));
                if(inventorySlots.list[i].ammount <= 0)
                {
                    inventorySlots.list.Remove(inventorySlots.list[i]);
                }
                return;
            }
        }
    }
}
