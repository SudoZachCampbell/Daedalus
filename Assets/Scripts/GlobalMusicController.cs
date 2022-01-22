using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMusicController : MonoBehaviour
{
    public bool beingChased = false;
    bool stateChange = false;
    public AudioClip backgroundMusic;
    public AudioClip chaseMusic;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!stateChange && beingChased) 
        {  
            stateChange = true;
            audioSource.Stop();
            audioSource.clip = chaseMusic;
            audioSource.Play();
        }
        if (stateChange && !beingChased)
        {
            stateChange = false;
            audioSource.Stop();
            audioSource.clip = backgroundMusic;
            audioSource.Play();
        }
    }
}
