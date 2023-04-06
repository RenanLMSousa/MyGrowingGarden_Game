using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIShop : MonoBehaviour
{//This class does not require the shop script, but does need an ItemListType to create the shop interface



    public Card cardPrefab; 
    public Transform cardObjectParent;
    public ItemListType stockItemList;


    private List<Card> instantiatedCardsList = new List<Card>();

    private void Awake()
    {

    }
    void Start()
    {
        InitializeGridElements();
        InitializeStock();
    }
    private void InitializeStock()
    {   //When the stock changes, updates the Grid elements
        //TODO delete the previous elements when it changes

        for (int i = 0; i < stockItemList.itemList.Count; i++)
        {
            Item _item = stockItemList.itemList[i];
            instantiatedCardsList[i].SetItem(_item);

        }
    }
    void InitializeGridElements()
    {   //Creates the grid elements, one for each item
        for (int i = 0; i < stockItemList.itemList.Count; i++)
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
        Card _gridCard = MonoBehaviour.Instantiate(cardPrefab);
        instantiatedCardsList.Add(_gridCard);
        _gridCard.transform.SetParent(cardObjectParent);
        _gridCard.transform.localScale = new Vector3(1, 1, 1);
        _gridCard.gameObject.AddComponent<ShopCardOnClick>();

    }
}
