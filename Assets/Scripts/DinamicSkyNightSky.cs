using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinamicSkyNightSky : MonoBehaviour
{

    public GameObject stars;


    public void Update()
    {
        stars.SetActive(isNight());
    }
    public bool isNight()
    {
        return DayAndNightCycle.GetTimeNormalized() * 24 > 18f || DayAndNightCycle.GetTimeNormalized() * 24 <= 06f;
    }

}
