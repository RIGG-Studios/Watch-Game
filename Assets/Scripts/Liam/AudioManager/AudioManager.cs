using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : EventBase
{
    public AudioSource audioSource;

    public AudioClip[] insertSoundEffects;
    public AudioClip[] buySoundEffects;
    public AudioClip[] clickSoundEffects;
    private AudioClip FindRandomInsertSound() => insertSoundEffects[Random.Range(0, insertSoundEffects.Length)];
    private AudioClip FindRandomBuySound() => buySoundEffects[Random.Range(0, buySoundEffects.Length)];
    private AudioClip FindRandomClickSound() => clickSoundEffects[Random.Range(0, clickSoundEffects.Length)];

    public override void ObjectInsertedCallback()
    {
        audioSource.PlayOneShot(FindRandomInsertSound());
    }

    public void PlayBuySound()
    {
        audioSource.PlayOneShot(FindRandomBuySound());
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(FindRandomClickSound());
    }
}
