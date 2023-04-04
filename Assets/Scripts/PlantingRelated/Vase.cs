using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Vase : MonoBehaviour
{
    [SerializeField]
    public VaseScriptableObject vaseScriptableObject;
    private bool isPlantedOn;

    public float productionMultiplier;
    public float growthAcceleration;

    public void SetVase(VaseScriptableObject vaseScriptableObject)

    {
        this.vaseScriptableObject = vaseScriptableObject;
        if(vaseScriptableObject != null) {
            productionMultiplier = vaseScriptableObject.productionMultiplier;
            growthAcceleration = vaseScriptableObject.growthAcceleration;
        }
        OnAwake();

    }
    public void OnAwake()
    {
        this.GetComponent<SpriteRenderer>().sprite = vaseScriptableObject.vaseSprite;
        isPlantedOn = false;
    }

   public bool GetIsPlantedOn()
    {   
        return isPlantedOn;
    }
    public void SetIsPlantedOn(bool isPlantedOn)
    {
        this.isPlantedOn = isPlantedOn;
    }
    public Vector2 GetVaseTop()
    {   //Return the position where the plant should grow
        return this.transform.position + new Vector3(0,1,0);
    }
    public Sprite getSprite()
    {
        return vaseScriptableObject.vaseSprite;
    }
    public float GetGrowthAcceleration()
    {
        return this.growthAcceleration;
    }
    public float GetProductionMultiplier()
    {
        return this.productionMultiplier;
    }
}
