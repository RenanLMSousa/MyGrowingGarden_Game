using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToCamView : MonoBehaviour
{

    private Vector2 screenResolution;

    private void Start()
    {
        screenResolution = new Vector2(Screen.width, Screen.height);
        MatchPlaneToScreenSize();
    }

    void MatchPlaneToScreenSize()
    {
        
        float planeToCameraDistance = Vector3.Distance(gameObject.transform.position, Camera.main.transform.position);
        float planeHeightScale = (2f * Mathf.Tan(0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad) * planeToCameraDistance);
        float planeWidthScale = planeHeightScale * Camera.main.aspect;
        gameObject.transform.localScale = new Vector3(planeWidthScale, planeHeightScale, 1);
    }
}
