using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceSoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip peaceSound;

    static AudioSource sAudioSource;
    static AudioClip sPeaceSound;

    // Start is called before the first frame update
    void Start()
    {
        sAudioSource = audioSource;
        sPeaceSound = peaceSound;
    }

    public static void changeAmbienceSounds()
    {
        sAudioSource.clip = sPeaceSound;
        sAudioSource.Play();
    }
}
