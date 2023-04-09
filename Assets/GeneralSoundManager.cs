using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GeneralSoundManager : MonoBehaviour
{
    public static GeneralSoundManager generalSoundManager;

    [Header("Sound Effects")]
    public SoundManager soundManager;

    public SoundType SFXOpenUI;
    public SoundType SFXCloseUI;

    public SoundType SFXBuyItem;
    public SoundType SFXCantBuyItem;

    public SoundType SFXPutVase;
    public SoundType SFXPlantCrop;

    public SoundType SFXHarvestCrop;

    public SoundType SFXBuyNewArea;

    public SoundType SFXCropGrown;

    [Header("Audio Sources")]
    public AudioSource effectsAudioSource;
    public AudioSource musicAudioSource;
    public AudioSource ambientAudioSource;

   
    private void Awake()
    {
        generalSoundManager = this;
    }
    private void Start()
    {
        SetMusicVolume(soundManager.MusicVolume);
        SetEffectsVolume(soundManager.EffectsVolume);
    }
    public void PlaySoundEffect(SoundType type)
    {
        effectsAudioSource.PlayOneShot(type.audioClip, soundManager.EffectsVolume);

    }

    public void PlaySFXOpenUI()
    {
        PlaySoundEffect(SFXOpenUI);
    }
    public void PlaySFXCloseUI()
    {
        PlaySoundEffect(SFXCloseUI);
    }
    public void PlaySFXBuyItem()
    {
        PlaySoundEffect(SFXBuyItem);
    }
    public void PlaySFXCantBuyItem()
    {
        PlaySoundEffect(SFXCantBuyItem);
    }
    public void PlaySFXPutVase()
    {
        PlaySoundEffect(SFXPutVase);
    }
    public void PlaySFXPlantCrop()
    {
        PlaySoundEffect(SFXPlantCrop);
    }
    public void PlaySFXHarvestCrop()
    {
        PlaySoundEffect(SFXHarvestCrop);
    }
    public void PlaySFXBuyNewArea()
    {
        PlaySoundEffect(SFXBuyNewArea);
    }
    public void PlaySFXCropGrown()
    {
        PlaySoundEffect(SFXCropGrown);
    }
    public void SetEffectsVolume(float f)
    {
        soundManager.EffectsVolume = f;
        effectsAudioSource.volume = f;
    }
    public void SetMusicVolume(float f)
    {
        soundManager.MusicVolume = f;
        musicAudioSource.volume = f;
    }
    
}
