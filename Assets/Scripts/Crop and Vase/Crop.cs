using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Crop:MonoBehaviour
{


    public CropScriptableObject cropScriptableObject;

    private float growingTime;
    private bool isPlanted;
    

    private int totalStages;
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
        IncrementTime();
        if (this.growingTime < cropScriptableObject.growthTime)
        {
            OnStageChanged();
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
        if (this.growingTime > cropScriptableObject.growthTime) {
            this.growingTime = cropScriptableObject.growthTime;
        }

    }
    public void OnStageChanged()
    {//When the plant changes it's growth stage this functions updates it's sprite
        int _growingStage = GetStageFromTime(growingTime);

        if (this.currentStage != _growingStage)
        {
            currentStage = GetStageFromTime(growingTime);
            this.GetComponent<SpriteRenderer>().sprite = cropScriptableObject.spritePhase[currentStage];
        }
    }
    public bool GetIsPlanted()
    {   
        return isPlanted;
    }
    void SetGrowingTime(float growingTime)
    { 
        this.growingTime = growingTime;
    }
    float GetGrowingTime()
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
        return (int)((this.growingTime / cropScriptableObject.growthTime) * (totalStages));
    }
    private bool IsGrown()
    {   //Checks if the plant is grown
        return cropScriptableObject.growthTime < this.growingTime;
    }
    public Sprite getGrownSprite()
    {
        return cropScriptableObject.spritePhase[cropScriptableObject.spritePhase.Count - 1];
    }
}
