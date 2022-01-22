using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMusicController : MonoBehaviour
{
    AudioSource myAudioSource;
    float countDown;
    public bool beingChased;
    bool ready = false;
    bool playing = false;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        countDown = Random.Range(5.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown > 0) {
            countDown -= Time.deltaTime;
        }
        if (countDown < 0) {
            ready = true;
            playNewAmbient();
            countDown = Random.Range(5.0f, 10.0f);
        }
        double b = System.Math.Round(countDown, 2);
        Debug.Log(b.ToString());
    }

    void playNewAmbient() {
        if (ready && !playing) {
            myAudioSource.Play();
            playing = true;
        }
    }
}
