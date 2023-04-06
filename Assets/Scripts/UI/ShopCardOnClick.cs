using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopCardOnClick : MonoBehaviour, IPointerClickHandler
{

    Card card;
    void Awake()
    {
        card = this.GetComponent<Card>();
    }

    // Update is called once per frame
    public void OnPointerClick(PointerEventData eventData)
    {

        //Change sometime in the future
        Debug.LogWarning("Direct player reference");
        GameManager.gameManager.player.BuyItem(card.GetItem(),1);


    }
}
