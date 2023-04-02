using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShelfManager : MonoBehaviour
{
    [Header("Scriptable Objects Type")]
    public CropVasePairType currentCropPairType;
    public InventorySlotListType playerInventory;

    [Header("Image type")]
    public Image cropImage;
    public Image vaseImage;

    [Header("UI objects")]
    public GameObject cropContentObject;
    public GameObject vaseContentObject;
    public GameObject backgroundObject;

    [Header("Prefabs")]
    public GameObject cropCardPrefab;
    public GameObject vaseCardPrefab;

    private List<GameObject> vasePool;
    private List<GameObject> cropPool;

    public void Awake()
    {
        vasePool = new List<GameObject>();
        cropPool = new List<GameObject>();
    }
    public void UpdateShop()
    {
        foreach (InventorySlot invSlot in playerInventory.list) {

            if(invSlot.item.ItemScriptableObject is VaseScriptableObject)
            {
                GameObject go = Instantiate(vaseCardPrefab);
                go.transform.SetParent(vaseContentObject.transform);
                vasePool.Add(go);
            }
            else if (invSlot.item.ItemScriptableObject is CropScriptableObject)
            {
                GameObject go = Instantiate(cropCardPrefab);
                go.transform.SetParent(cropContentObject.transform);
                cropPool.Add(go);
            }
        }
    }

    public void ShowShelfManager()
    {   
        if(currentCropPairType.cropVasePair.crop != null)
            cropImage.sprite = currentCropPairType.cropVasePair.crop.getGrownSprite();
        if (currentCropPairType.cropVasePair.vase != null)
            vaseImage.sprite = currentCropPairType.cropVasePair.vase.getSprite();
        backgroundObject.SetActive(true);
    }

}