using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class SoundManager : AutoCleanupSingleton<SoundManager>
{
    [SerializeField] private AudioSource moveSource;

    public void Play(AudioClip clip)
    {
        moveSource.clip = clip;
        moveSource.Play();

    }
}
