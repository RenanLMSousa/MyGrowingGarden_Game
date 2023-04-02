using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIVaseCardGenerateGrid : MonoBehaviour
{
    public GameObject parentGameObject;
    public Card prefabCardUIObject;
    public UnityEvent onClickComponent;

    public InventorySlotListType playerInventory;

    public void OnEnable()
    {
        GenerateGrid();
    }
    public void GenerateGrid()
    {
        foreach(InventorySlot slot in playerInventory.list)
        {
            if(slot.item.ItemScriptableObject is VaseScriptableObject)
            {
                Card card = Instantiate(prefabCardUIObject);
                card.transform.SetParent(parentGameObject.transform);
                card.SetItem(slot.item);
                card.transform.localScale = new Vector3(1, 1, 1);
                card.gameObject.AddComponent<OnVaseCardClick>();
            }
        }
    }
}
