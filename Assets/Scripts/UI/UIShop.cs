using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ShopGrid
{
    public UIShopGridElement gridElementPrefab;
    public GameObject itemGrid;
    
    [HideInInspector]
    public Shop shop;
    [HideInInspector]
    public List<UIShopGridElement> itemGridElementList;
    public ShopStockScriptableObject shopStockScriptableObject;

    public ShopGrid shopGrid;




   

}
public class UIShop : MonoBehaviour
{

    public ShopGrid shopGrid;

    void Awake()
    {

        shopGrid.shop = new Shop(shopGrid.shopStockScriptableObject.itemStock);
        shopGrid.shop.StockChanged += OnStockChanged;

    }
    private void Start()
    {
        InitializeGrid();
        OnStockChanged();
    }
    private void OnStockChanged()
    {

        for (int i = 0; i < shopGrid.itemGridElementList.Count; i++)
        {
            Item item = shopGrid.shop.AvailableItems[i];
            if (item != null)
            {
                shopGrid.itemGridElementList[i].displayItem(item);
            }

        }
    }
    void InitializeGrid()
    {
        for (int i = 0; i < shopGrid.shop.AvailableItems.Count; i++)
        {
            UIShopGridElement _gridElement = MonoBehaviour.Instantiate(shopGrid.gridElementPrefab);
            shopGrid.itemGridElementList.Add(_gridElement);
            _gridElement.transform.SetParent(shopGrid.itemGrid.transform);
            _gridElement.transform.localScale = new Vector3(1, 1, 1);

        }
    }
}
