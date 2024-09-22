using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1;

    public void PlayButtonSound() {
        src.clip = sfx1;
        src.Play();
    }

    public void OptionsButtonSound() {
        src.clip = sfx1;
        src.Play();
    }

    public void QuitButtonSound() {
        src.clip = sfx1;
        src.Play();
    }
}
