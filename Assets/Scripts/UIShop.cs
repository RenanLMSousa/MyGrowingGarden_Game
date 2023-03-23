using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ShopGrid
{
    public UIShopGridElement gridElementPrefab;
    public GameObject itemGrid;
    

    public Shop shop;
    public List<UIShopGridElement> itemGridElementList;



}
public class UIShop : MonoBehaviour
{

    public ShopGrid shopGrid;

    


    private void Awake()
    {
        shopGrid.shop = this.GetComponent<Shop>();
        shopGrid.itemGridElementList = new List<UIShopGridElement>();
        shopGrid.shop.StockChanged += OnStockChanged;
        InitializeGrid();

    }
    private void OnStockChanged()
    {


        for (int i = 0; i < Shop.shopSize; i++)
        {
            
            shopGrid.itemGridElementList[i].displayItem(shopGrid.shop.AvailableItems[i]);

        }
    }
    void InitializeGrid()
    {
        for (int i = 0; i < Shop.shopSize; i++)
        {
            UIShopGridElement _gridElement = Instantiate(shopGrid.gridElementPrefab);
            shopGrid.itemGridElementList.Add(_gridElement);
            _gridElement.transform.SetParent(shopGrid.itemGrid.transform);
            _gridElement.transform.localScale = new Vector3(1, 1, 1);

        }
    }
}
