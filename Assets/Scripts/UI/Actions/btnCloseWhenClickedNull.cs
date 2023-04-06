using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class btnCloseWhenClickedNull : MonoBehaviour, IPointerClickHandler
{
    public List<GameObject> targetObjects;

    public void OnPointerClick(PointerEventData eventData)
    {
        foreach (GameObject go in targetObjects)
        {
            
            go.SetActive(false);
        }
    }
}
