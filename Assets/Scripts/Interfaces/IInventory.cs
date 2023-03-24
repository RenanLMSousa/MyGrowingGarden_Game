using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory
{

    public void RemoveFromInventory(Item item, int ammount);
    public void AddToInventory(Item item, int ammount);
}
