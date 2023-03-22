using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vase", menuName = "ScriptableObjects/New Vase", order = 1)]
public class VaseScriptableObject : ScriptableObject
{
    public Sprite vaseSprite;
    public string vaseName;
    public string vaseDescription;
    public float buyingValue;
    public float sellingValue;

}
