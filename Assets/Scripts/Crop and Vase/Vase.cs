using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Vase : MonoBehaviour
{
    [SerializeField]
    private VaseScriptableObject vaseScriptableObject;
    private bool isPlantedOn;

    private void Awake()
    {
        this.GetComponent<SpriteRenderer>().sprite = vaseScriptableObject.vaseSprite;
        isPlantedOn = false;
    }

   public bool GetIsPlantedOn()
    {   
        return isPlantedOn;
    }
    public void SetIsPlantedOn(bool isPlantedOn)
    {
        this.isPlantedOn = isPlantedOn;
    }
    public Vector2 GetVaseTop()
    {   //Return the position where the plant should grow
        return this.transform.position + new Vector3(0,1,0);
    }

}
