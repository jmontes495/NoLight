using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowSoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip glowSound;

    static AudioSource sAudioSource;
    static AudioClip sGlowSound;

    // Start is called before the first frame update
    void Start()
    {
        sAudioSource = audioSource;
        sGlowSound = glowSound;
    }

    /*public static void PlayGlowSound()
    {
        sAudioSource.clip = sGlowSound;
        sAudioSource.Play();
    }*/
}
