using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    //public AudioClip walkingSound;

    static AudioSource sAudioSource;
    //static AudioClip sWalkingSound;

    // Start is called before the first frame update
    void Start()
    {
        sAudioSource = audioSource;
        //sWalkingSound = walkingSound;
    }

    public static void PlayWalkingSound()
    {
        //sAudioSource.clip = sWalkingSound;
        sAudioSource.Play();
    }

    public static void StopWalkingSound()
    {
        sAudioSource.Stop();
    }
}
