using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIShopGridElement : MonoBehaviour
{
    public TMP_Text text;
    public Image image;

    public void displayItem(Item item)
    {
        if(item == null)
        {
            this.gameObject.SetActive(false);
            return;
        }
        text.text = item.GetName();
        image.sprite = item.GetSprite();
        
        
    }
}
