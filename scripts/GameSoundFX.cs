using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundFX : MonoBehaviour
{
    public AudioSource src;
    public AudioClip jump;
    public AudioClip hit; 
    public AudioClip death;
    public AudioClip attack;

    public void PlayJumpSound() {
        src.clip = jump;
        src.Play();
    } 

    public void PlayHitSound() {
        src.clip = hit;
        src.Play();
    }

    public void PlayAttackSound() {
        src.clip = attack;
        src.Play();
    }

    public void PlayDeathSound() {
        src.clip = death;
        src.Play();
    }
}
