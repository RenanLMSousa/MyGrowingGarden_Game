using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UIItemTemplateClickeable : MonoBehaviour ,IPointerClickHandler
{
    private UIShopGridElement uiShopCropGridElement;
    
    void Awake()
    {
        uiShopCropGridElement = this.GetComponent<UIShopGridElement>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {   
        Debug.Log(uiShopCropGridElement.item.GetName());
        Debug.Log(uiShopCropGridElement.itemScriptableObject is CropScriptableObject);
        Debug.Log(GameManager.gameManager.player.playerName);
  
    }

}
