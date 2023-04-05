using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VaseCard : Card
{

    public TMP_Text txtGrowthAcceleration;
    public TMP_Text txtProductionMultiplier;

    protected override void UpdateCardSpecific()
    {
        if (item != null)
        {
            VaseScriptableObject vaseSo = item.ItemScriptableObject as VaseScriptableObject;
            txtGrowthAcceleration.text = vaseSo.growthAcceleration.ToString();
            txtProductionMultiplier.text = vaseSo.productionMultiplier.ToString();
        }
        else
        {
            txtGrowthAcceleration.text = "";
            txtProductionMultiplier.text = "";
        }
        
    }
}
