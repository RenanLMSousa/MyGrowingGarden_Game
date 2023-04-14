using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIPriceTag : MonoBehaviour
{
    Card card;
    float price;
    public TMP_Text txtPrice;
    public void OnEnabled()
    {

        card = this.transform.parent.GetComponent<Card>();
        this.transform.localScale = new Vector3(1, 1, 1);
        price = card.GetItem().GetBuyingPrice();
        txtPrice.text = UnityConversor.moneyToK(price);
    }
}
