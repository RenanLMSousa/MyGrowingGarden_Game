using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Crop:MonoBehaviour
{


    public CropScriptableObject cropScriptableObject;

    [SerializeField]
    private float growingTime;
    private bool isPlanted;

    private float sellingValue;
    private float growthTime;

    private int totalStages;
    private int currentStage;


    public void SetCrop(CropScriptableObject cropScriptableObject)
    {
        this.cropScriptableObject = cropScriptableObject;
        OnAwake();
    }
    public void OnAwake()
    {   
        
        if (cropScriptableObject != null)
        {
            growthTime = cropScriptableObject.growthTime;
            sellingValue = cropScriptableObject.sellingPrice;
            isPlanted = true;
            growingTime = 0f;
            InitializeTextures();
            InitializeStages();
        }

    }

    public void SetNull()
    {
        growingTime = 0f;
        isPlanted = false;
        totalStages = 0;
        currentStage = 0;
        cropScriptableObject = null;
        this.sellingValue = 0 ;
        this.GetComponent<SpriteRenderer>().sprite = null;
    }

    void Update()
    {   if (cropScriptableObject != null)
        {


            IncrementTime();
            OnStageChanged();

        }
        else
        { //Debug.Log("Tem que verificar se o SO não é nulo"); 
        }
    }

    public void SetIsPlanted(bool isPlanted)
    {   //Set if tha plant is planted or not and its consequences accordingly
        
        this.isPlanted = isPlanted;
        if(isPlanted == false){
            growingTime = 0;
        }

    }
    public void IncrementTime()
    { 

        if (isPlanted && !IsGrown()) { 
           SetGrowingTime(growingTime + Time.deltaTime);
        }
        if (this.growingTime > GetGrowthTime()) {
            this.growingTime = GetGrowthTime();
        }

    }
    public void OnStageChanged()
    {//When the plant changes it's growth stage this functions updates it's sprite
        if (currentStage >= totalStages) { return; }
        int _growingStage = GetStageFromTime(growingTime);
        
        if (this.currentStage != _growingStage)
        {
            currentStage = GetStageFromTime(growingTime);
            this.GetComponent<SpriteRenderer>().sprite = cropScriptableObject.spritePhase[Mathf.Min(currentStage,totalStages-1)];
        }
    }
    public bool GetIsPlanted()
    {   
        return isPlanted;
    }
    public void SetGrowingTime(float growingTime)
    { 
        this.growingTime = growingTime;
    }
    public float GetGrowingTime()
    {
        return this.growingTime;
    }

    void InitializeTextures()
    {   //Set the object texture
        this.GetComponent<SpriteRenderer>().sprite = cropScriptableObject.spritePhase[0];
    }
    void InitializeStages()
    {   //Initialize the stage count and defines the max number of stages
        this.currentStage = 0;
        this.totalStages = cropScriptableObject.spritePhase.Count;
    }
    private int GetStageFromTime(float time)
    {   //Given a time, returns the stage
        return (int)((this.growingTime / GetGrowthTime()) * (totalStages));
    }
    public bool IsGrown()
    {   //Checks if the plant is grown
        if (cropScriptableObject == null) return false;
        return GetGrowthTime() <= this.growingTime;
    }
    public Sprite getGrownSprite()
    {
        return cropScriptableObject.spritePhase[cropScriptableObject.spritePhase.Count - 1];
    }
    public float GetTimeLeft()
    {
        return this.growthTime - this.growingTime;
    }
    public float GetSellingValue()
    {
        return this.sellingValue;

    }
    public void SetSellingValue(float sellingValue)
    {
        this.sellingValue = sellingValue;

    }
    public void SetGrowthTime(float growthTime)
    {
        this.growthTime = growthTime;
    }
    public float GetGrowthTime()
    {
        return this.growthTime;
    }
    public string GetSOName()
    {
        return cropScriptableObject == null ? null : cropScriptableObject.name;
    }
    public int GetTier()
    {
        return cropScriptableObject==null? 0 : cropScriptableObject.tier;
    }
}
