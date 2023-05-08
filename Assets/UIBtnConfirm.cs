using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UIBtnConfirm : MonoBehaviour, IPointerClickHandler
{
    public TMP_Text txtField;
    public GameObject closeAfterConfirmObject;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.gameManager.player.playerName = txtField.text;
        closeAfterConfirmObject.SetActive(false);
    }
}
