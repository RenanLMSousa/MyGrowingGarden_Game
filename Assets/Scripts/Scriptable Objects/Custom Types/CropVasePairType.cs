using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crop Vase Pair Type", menuName = "ScriptableObjects/Crop Vase Pair Type", order = 1)]
public class CropVasePairType : ScriptableObject
{
    [HideInInspector]
    public CropVasePair cropVasePair = new CropVasePair();

 
  
}
