using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crop", menuName = "ScriptableObjects/New Crop", order = 1)]
public class CropScriptableObject : ScriptableObject
{
    public List<Sprite> spritePhase;
    public string plantName;
    public string plantDescription;
    public float buyingValue;
    public float sellingValue;
    public float growthTime;

}
