using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Audio Confif" , menuName = "Audio/AudioConfig")]
public class SoundManager : ScriptableObject
{
    [Range(0f,1f)]
    public float EffectsVolume = 1f;
    [Range(0f, 1f)]
    public float MusicVolume = 1f;

}
