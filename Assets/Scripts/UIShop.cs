using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShop : MonoBehaviour
{
    public UIShopGridElement gridElementPrefab;
    public Shop shop;
    public List<UIShopGridElement> cropGridElementList;
    public List<UIShopGridElement> vaseGridElementList;

    public GameObject cropGrid;
    public GameObject vaseGrid;

    private void Awake()
    {
        cropGridElementList = new List<UIShopGridElement>();
        vaseGridElementList = new List<UIShopGridElement>();
        shop.StockChanged += OnStockChanged;
    }
    private void Start()
    {
        for(int i = 0; i < Shop.shopSize; i++)
        {
            UIShopGridElement _gridElement = Instantiate(gridElementPrefab);
            cropGridElementList.Add(_gridElement);
            _gridElement.transform.SetParent(cropGrid.transform);
            _gridElement.transform.localScale = new Vector3(1, 1, 1);

            _gridElement = Instantiate(gridElementPrefab);
            vaseGridElementList.Add(_gridElement);
            _gridElement.transform.SetParent(vaseGrid.transform);
            _gridElement.transform.localScale = new Vector3(1, 1, 1);

        }

    }
    private void OnStockChanged()
    {
        for (int i = 0; i < Shop.shopSize; i++)
        {
            cropGridElementList[i].displayItem(Shop.AvailableCrops[i]);
            vaseGridElementList[i].displayItem(Shop.AvailableVases[i]);

        }
    }
}
