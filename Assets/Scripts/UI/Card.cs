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

    public TMP_Text txtAmmount;

    public GameEvent onPlantAreaChange;

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
    {   if (item != null)
        {
            this.imgImage.sprite = item.GetSprite();
            this.txtName.text = item.GetName();
            this.txtTier.text = item.GetTier().ToString();
        }
        else
        {
            this.imgImage.sprite = null;
            this.txtName.text = "";
            this.txtTier.text = "";
        }
    }
    public Item GetItem()
    {
        return this.item;
    }
    public ItemScriptableObject GetItemSo()
    {
        return this.item.ItemScriptableObject;
    }
    public void SetAmmount(int ammount)
    {

        txtAmmount.text = ammount.ToString();
        

    }

}
