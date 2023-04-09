using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public static float EffectsVolume;
    public static float MusicVolume;

    public Slider musicSlider;
    public Slider effecsSlider;

    public SoundManager soundManager;
    public void Awake()
    {

        EffectsVolume = soundManager.EffectsVolume;
        MusicVolume = soundManager.MusicVolume;
    }

    private void Start()
    {
        effecsSlider.value = EffectsVolume;
        musicSlider.value = MusicVolume;
    }

    public void SetEffectsVolume()
    {
        GeneralSoundManager.generalSoundManager.SetEffectsVolume(effecsSlider.value);
    }
    public void SetMusicVolume()
    {

        GeneralSoundManager.generalSoundManager.SetMusicVolume( musicSlider.value);
    }
}
