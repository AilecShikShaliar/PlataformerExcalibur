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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
