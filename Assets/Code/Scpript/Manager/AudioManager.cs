using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //SONIDOS A REPRODUCIR 
    public AudioSource[] soundsEffects;

    //SINGLETON 
    public static AudioManager audioReference;


    private void Awake()
    {
        
        if (audioReference == null)
            audioReference = this;
    }


    public void PlaySFX (int soundtoPlay)
    {
        soundsEffects[soundtoPlay].Stop();
        soundsEffects[soundtoPlay].Play();
    }
}
