using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Vase : MonoBehaviour,IItem
{

    public VaseScriptableObject vaseScriptableObject;
    private bool isPlantedOn;

    private void Awake()
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
    {
        return this.transform.position + new Vector3(0,1,0);
    }

    public float GetBuyingPrice()
    {
        throw new System.NotImplementedException();
    }

    public float GetSellingPrice()
    {
        throw new System.NotImplementedException();
    }

    public void SetBuyingPrice(float buyingPrice)
    {
        throw new System.NotImplementedException();
    }

    public void SetSellingPrice(float sellingPrice)
    {
        throw new System.NotImplementedException();
    }

    public Sprite GetSprite()
    {
        return vaseScriptableObject.vaseSprite;
    }

    public string GetName()
    {
        return vaseScriptableObject.name;
    }
}
