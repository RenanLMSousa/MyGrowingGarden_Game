using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnVaseCardClick : MonoBehaviour , IPointerClickHandler
{
    Item item;
    public CropVasePairType selectedCropVase;
    public void Awake()
    {
        item = this.GetComponent<Card>().GetItem();
    }
    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
