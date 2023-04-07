using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlantSpotInfo : MonoBehaviour
{
    public List<GameObject> targetGameobjects;
    private void OnDisable()
    {
     foreach(GameObject gameObject in targetGameobjects)
        {
            gameObject.SetActive(false);
        }   
    }
}
