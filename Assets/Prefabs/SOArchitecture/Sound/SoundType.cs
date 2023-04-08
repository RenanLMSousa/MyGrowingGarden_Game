using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sound Type" , menuName = "Audio/Sound")]
public class SoundType : ScriptableObject
{
    public AudioClip audioClip;

    public float privateVolume;
    public bool loop;


}
