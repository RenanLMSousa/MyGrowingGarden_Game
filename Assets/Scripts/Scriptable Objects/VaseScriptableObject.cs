using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vase", menuName = "ScriptableObjects/New Vase", order = 1)]
public class VaseScriptableObject : ItemScriptableObject
{
    public Sprite vaseSprite;
    public string vaseName;
    public string vaseDescription;

    public override Sprite GetItemSprite()
    {
        return vaseSprite;
    }
}
