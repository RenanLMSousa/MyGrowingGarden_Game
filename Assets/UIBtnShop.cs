using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIBtnShop : MonoBehaviour, IPointerClickHandler
{

    public List<GameObject> openOnClickObjects;
    public List<GameObject> closeOnClickObjects;

    public void OnPointerClick(PointerEventData eventData)
    {

        OpenOnClick();
        CloseOnClick();
        
    }

    void OpenOnClick() {
    
        foreach(GameObject go in openOnClickObjects)
        {   
            go.SetActive(!go.activeSelf);
            if (go.activeSelf)
                GeneralSoundManager.generalSoundManager.PlaySFXOpenUI();
            else
                GeneralSoundManager.generalSoundManager.PlaySFXCloseUI();
        }
    }

    void CloseOnClick() {

        foreach (GameObject go in closeOnClickObjects)
        {
            go.SetActive(false);
        }
    }
}
