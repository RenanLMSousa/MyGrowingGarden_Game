using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIBtnTimeIncrease : MonoBehaviour , IPointerClickHandler
{
    public FloatType playerMoney;
    private float _timeSinceLastClick = 0;
    private float clickCooldown = 1;

    private void Update()
    {
        _timeSinceLastClick += Time.deltaTime;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        getOnclickBonus();
    }

    private void getOnclickBonus()
    {
        if (_timeSinceLastClick >= clickCooldown)
        {   
            //+1s/spot owned
            PlantingSpotManager.IncreaseGrowingTimeAbsolute(PlantingSpotManager.ownedPlantingSpots.Count);
            _timeSinceLastClick = 0;
        }
    }

}
