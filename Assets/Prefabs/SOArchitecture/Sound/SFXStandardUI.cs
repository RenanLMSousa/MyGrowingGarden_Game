using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXStandardUI : SFXPlayer
{

    public SoundType SFXOpenUI;
    public SoundType SFXCloseUI;

    public void playOpenUI() {

        audioSource.PlayOneShot(SFXOpenUI.audioClip, soundManager.EffectsVolume);
    }

    public void playCloseUI() {

        audioSource.PlayOneShot(SFXCloseUI.audioClip, soundManager.EffectsVolume);
    }
}
