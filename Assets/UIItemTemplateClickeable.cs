using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UIItemTemplateClickeable : MonoBehaviour ,IPointerClickHandler
{
    ItemScriptableObject itemScriptableObject;
    private UIShopGridElement uiShopCropGridElement;
    
    void Awake()
    {
        uiShopCropGridElement = this.GetComponent<UIShopGridElement>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(uiShopCropGridElement.item.GetName());
  
    }

}
