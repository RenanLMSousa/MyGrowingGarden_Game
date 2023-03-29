using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ShopGrid
{
    public UIShopGridElement gridElementPrefab;
    public GameObject itemGrid;

    public ItemListType itemList;
    [HideInInspector]
    public List<UIShopGridElement> itemGridElementList;


   


}
public class UIShop : MonoBehaviour
{//This class does not require the shop script, but does need an ItemListType to create the shop interface


    public ShopGrid shopGrid;


    void Start()
    {
        InitializeGridElements();
        OnStockChanged();
    }
    private void OnStockChanged()
    {   //When the stock changes, updates the Grid elements

        for (int i = 0; i < shopGrid.itemGridElementList.Count; i++)
        {
            UIShopGridElement gridElement = shopGrid.itemGridElementList[i];
            Item item = shopGrid.itemList.itemList[i];
            ChangeGridElementDisplay(gridElement, item);

        }
    }
    void InitializeGridElements()
    {   //Creates the grid elements, one for each item
        for (int i = 0; i < shopGrid.itemList.itemList.Count; i++)
        {
            CreateNewGridElement();
        }
    }
    private void ChangeGridElementDisplay(UIShopGridElement gridElement,Item item) {
        //Change the item being displayed
        gridElement.DisplayItem(item);
    }
    private void CreateNewGridElement()
    {   //Create a new grid element as last
        UIShopGridElement _gridElement = MonoBehaviour.Instantiate(shopGrid.gridElementPrefab);
        shopGrid.itemGridElementList.Add(_gridElement);
        _gridElement.transform.SetParent(shopGrid.itemGrid.transform);
        _gridElement.transform.localScale = new Vector3(1, 1, 1);

    }
}
