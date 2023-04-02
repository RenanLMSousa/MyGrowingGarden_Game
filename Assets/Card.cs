using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card : MonoBehaviour
{
    protected Item item;

    public Image imgImage;
    public TMP_Text txtName;
    public TMP_Text txtTier;
    public TMP_Text txtDescription;

    protected abstract void UpdateCardSpecific();
    public void UpdateCard()
    {
        UpdateCardGeneric();
        UpdateCardSpecific();
    }
    public void SetItem(Item item)
    {
        this.item = item;
        UpdateCard();
    }
    protected void UpdateCardGeneric()
    {
        this.imgImage.sprite = item.GetSprite();
        this.txtName.text = item.GetName();
        this.txtTier.text = item.GetTier().ToString();
     
    }
    public Item GetItem()
    {
        return this.item;
    }


}
