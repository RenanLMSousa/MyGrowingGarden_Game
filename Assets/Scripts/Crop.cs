using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Crop:MonoBehaviour, IItem
{


    [SerializeField]
    private float growingTime;
    [SerializeField]
    private bool isPlanted;
    public CropScriptableObject cropScriptableObject;

    private int totalStages;
    [SerializeField]
    private int currentStage;



    private void Awake()
    {   
        isPlanted = false;
        growingTime = 0f;
        InitializeTextures();
        InitializeStages();
    }

    void Update()
    {
        TimePassingEffect();
    }

    public void SetIsPlanted(bool isPlanted)
    {
        
        this.isPlanted = isPlanted;
        if(isPlanted == false){
            growingTime = 0;
        }

    }
    public void TimePassingEffect()
    {

        if (isPlanted && !IsGrown()) { 
           SetGrowingTime(growingTime + Time.deltaTime);
        }
    }
    public bool GetIsPlanted()
    {
        return isPlanted;
    }
    void SetGrowingTime(float growingTime)
    {
        int _growingStage = GetStageFromTime(growingTime);
        this.growingTime = growingTime;

        if(IsGrown()) { growingTime = cropScriptableObject.growthTime;}

        if(this.currentStage != _growingStage)
        {

            currentStage = GetStageFromTime(growingTime);
            this.GetComponent<SpriteRenderer>().sprite = cropScriptableObject.spritePhase[currentStage];
        }

    }
    float GetGrowingTime()
    {
        return this.growingTime;
    }

    void InitializeTextures()
    {   
        this.GetComponent<SpriteRenderer>().sprite = cropScriptableObject.spritePhase[0];
    }
    void InitializeStages()
    {
        this.currentStage = 0;
        this.totalStages = cropScriptableObject.spritePhase.Count;
    }
    private int GetStageFromTime(float time)
    {
        return (int)((this.growingTime / cropScriptableObject.growthTime) * (totalStages));
    }
    private bool IsGrown()
    {
        return cropScriptableObject.growthTime < this.growingTime;
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
        Debug.Log(totalStages);
        return cropScriptableObject.spritePhase[cropScriptableObject.spritePhase.Count-1];
    }

    public string GetName()
    {
        return cropScriptableObject.name;
    }
}
