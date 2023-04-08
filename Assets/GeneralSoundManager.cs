using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GeneralSoundManager : MonoBehaviour
{
    public static GeneralSoundManager generalSoundManager;

    public SoundManager soundManager;

    public SoundType SFXOpenUI;
    public SoundType SFXCloseUI;

    public SoundType SFXBuyItem;
    public SoundType SFXCantBuyItem;

    public SoundType SFXPutVase;
    public SoundType SFXPlantCrop;

    public SoundType SFXHarvestCrop;

    public SoundType SFXBuyNewArea;

    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
        generalSoundManager = this;
    }

    public void PlaySoundEffect(SoundType type)
    {
        audioSource.PlayOneShot(type.audioClip, soundManager.EffectsVolume);

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
}
