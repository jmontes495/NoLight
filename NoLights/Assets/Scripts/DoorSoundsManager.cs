using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSoundsManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip normalBreakSound;
    public AudioClip finalBreakSound;

    static AudioSource sAudioSource;
    static AudioClip sNormalBreakSound;
    static AudioClip sFinalBreakSound;

    // Start is called before the first frame update
    void Start()
    {
        sAudioSource = audioSource;
        sNormalBreakSound = normalBreakSound;
        sFinalBreakSound = finalBreakSound;
    }

    public static void playDoorSounds(int doorStatus)
    {
        if(doorStatus == 3)
        {
            sAudioSource.clip = sFinalBreakSound;
        }
        else
        {
            sAudioSource.clip = sNormalBreakSound;
        }

        sAudioSource.Play();
    }
}
