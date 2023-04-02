using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    public GameEvent onShelfManagerOpen;
    public CropVasePairType selectedCropVase;
    [HideInInspector]
    public Crop crop;
    [HideInInspector]
    public Vase vase;


    public void SetSelectedCropVase()
    {
        selectedCropVase.cropVasePair.crop = crop;
        selectedCropVase.cropVasePair.vase = vase;
    }

    public void OnMouseDown()
    {
        SetSelectedCropVase();
        onShelfManagerOpen.Raise();
    }
}
