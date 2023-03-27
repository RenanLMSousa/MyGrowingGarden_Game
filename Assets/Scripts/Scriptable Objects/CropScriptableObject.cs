using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crop", menuName = "ScriptableObjects/New Crop", order = 1)]
public class CropScriptableObject : ItemScriptableObject
{
    public List<Sprite> spritePhase;
    public string plantName;
    public string plantDescription;
    public float growthTime;

    public override Sprite GetItemSprite()
    {
        return spritePhase[spritePhase.Count -1];
    }
}
