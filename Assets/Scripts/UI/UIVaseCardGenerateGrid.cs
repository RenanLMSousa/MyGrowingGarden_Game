using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIVaseCardGenerateGrid : MonoBehaviour
{
    public GameObject parentGameObject;
    public Card prefabCardUIObject;
    public InventorySlotListType playerInventory;
    public GameEvent onCardClick;

    public void OnEnable()
    {
        UpdateGrid();
    }
    public void UpdateGrid() {
        FreeGrid();
        GenerateGrid();
    }
    public void FreeGrid()
    {
        foreach (Transform child in parentGameObject.transform)
        {
            Destroy(child.gameObject);
        }
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
                card.SetAmmount(slot.ammount);
                card.transform.localScale = new Vector3(1, 1, 1);
                card.gameObject.AddComponent<OnVaseCardClick>().onClickEvent = onCardClick;
                
            }
        }
    }
}
