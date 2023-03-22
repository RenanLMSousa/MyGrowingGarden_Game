using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory
{

    public void RemoveFromInventory(IItem item, int ammount);
    public void AddToInventory(IItem item, int ammount);
}
