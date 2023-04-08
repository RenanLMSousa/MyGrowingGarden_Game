using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNightCycle : MonoBehaviour
{
    public List<GameObject> affectedObjects;
    public Gradient gradientColors;

    public static float TimeOfTheDay = 0;

    private SpriteRenderer spriteRenderer;

    private static float periodInSecs = 24;

    private void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    public void Update()
    {
        TimeOfTheDay += Time.deltaTime;
        TimeOfTheDay = TimeOfTheDay % periodInSecs;
        spriteRenderer.color = gradientColors.Evaluate(TimeOfTheDay / periodInSecs);
    }
    
    public static float GetTimeNormalized()
    {
        return TimeOfTheDay / periodInSecs;
    }


}
