using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIShopGridElement : MonoBehaviour
{   //Gets atatched to the Shop Grid Element, and is responsible for changing it's layout when needed
    public TMP_Text text;
    public Image image;

    public void displayItem(Item item)
    {//Displays an item info
        if(item == null)
        {
            this.gameObject.SetActive(false);
            return;
        }
        text.text = item.GetName();
        image.sprite = item.GetSprite();
        
        
    }
}
