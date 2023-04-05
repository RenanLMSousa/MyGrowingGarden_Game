using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CropCard : Card
{
    public TMP_Text txtSellingPrice;
    public TMP_Text txtGrowthTime;
    protected override void UpdateCardSpecific()
    {
        if (item != null)
        {
            CropScriptableObject cropSO = item.ItemScriptableObject as CropScriptableObject;
            txtSellingPrice.text = cropSO.sellingPrice.ToString();
            txtGrowthTime.text = cropSO.growthTime.ToString();
        }
        txtGrowthTime.text = "";
        txtSellingPrice.text = "";
    }
}
