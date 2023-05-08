using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIBtnTime : MonoBehaviour, IPointerClickHandler
{
    public FloatType playerMoney;
    private const float BASEVALUE = 1;

    public void OnPointerClick(PointerEventData eventData)
    {
        getOnclickBonus();
    }

    private void getOnclickBonus()
    {

        PlantingSpotManager.IncreaseGrowingTimeAbsolute(BASEVALUE);
    }
}
