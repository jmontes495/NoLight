using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip offSound;
    public AudioClip onSound;

    static AudioSource sAudioSource;
    static AudioClip sOffSound;
    static AudioClip sOnSound;

    // Start is called before the first frame update
    void Start()
    {
        sAudioSource = audioSource;
        sOffSound = offSound;
        sOnSound = onSound;
    }

   
    public static void PlayLightsSounds(bool lightNewState)
    {
        if (lightNewState)
        {
            sAudioSource.clip = sOnSound;
        }
        else
        {
            sAudioSource.clip = sOffSound;
        }
        sAudioSource.Play();
    }
}
