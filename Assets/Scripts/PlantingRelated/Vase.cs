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

    public void SetNull()
    {
        this.vaseScriptableObject = null;
        this.isPlantedOn = false;
        this.productionMultiplier = 1;
        this.growthAcceleration = 1;
        this.GetComponent<SpriteRenderer>().sprite = null;
    }
    public void SetVase(VaseScriptableObject vaseScriptableObject)
    {
        if(vaseScriptableObject == null) { 
            SetNull();
            return;
        }
        this.vaseScriptableObject = vaseScriptableObject;  
        productionMultiplier = vaseScriptableObject.productionMultiplier;
        growthAcceleration = vaseScriptableObject.growthAcceleration;

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
        Sprite sprite = this.GetComponent<SpriteRenderer>().sprite;
        if (sprite == null) return Vector2.zero; 
        return this.transform.position + new Vector3(0, sprite.bounds.size.y/2,0);
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
    public string GetSOName()
    {
        
        return vaseScriptableObject == null ? null : vaseScriptableObject.name;
    }

    public int GetTier()
    {
        return vaseScriptableObject == null? 0 : vaseScriptableObject.tier;
    }
}
