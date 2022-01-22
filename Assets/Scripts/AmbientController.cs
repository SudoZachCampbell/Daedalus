using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AmbientController : MonoBehaviour
{
    float countDown;
    bool ready = false;
    bool playing = false;

    public AudioClip ambientOne;
    public AudioClip ambientTwo;
    public AudioClip ambientThree;
    public AudioClip ambientFour;

    AudioClip currentPlaying;

    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        setCountDown();
        setAudioClip();
    }

    //Sets a random timer between 30s and 60s to trigger audio effects
    void setCountDown()
    {
        countDown = Random.Range(30f, 60f);
    }

    //Chooses a random number between 1 and 4 to decide on clip to be played next
    void setAudioClip() 
    {
        float randNum = Random.Range(1f, 4f);
        int clipNo = (int)System.Math.Floor(randNum);
        switch (clipNo)
        {
            case 1:
                currentPlaying = ambientOne;
                break;
            case 2:
                currentPlaying = ambientTwo;
                break;
            case 3:
                currentPlaying = ambientThree;
                break;
            default:
                currentPlaying = ambientFour;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (countDown > 0)
        {
            countDown -= Time.deltaTime;
        }
        if (countDown < 0)
        {
            ready = true;
            StartCoroutine(playNewAmbient());
        }
    }

    //Plays assigned 
    IEnumerator playNewAmbient()
    {
        //If Audio clip isn't already playing, play next clip
        if (ready && !playing)
        {
            playing = true;
            AudioSource.PlayClipAtPoint(currentPlaying, new Vector3(Random.Range(-5f, 5f), 6, Random.Range(-5f, 5f)), 0.75f);

            //After the clip has ended, resets counter and sets next clip
            yield return new WaitForSeconds(currentPlaying.length);
            
            setAudioClip();
            setCountDown();
            playing = false;
            ready = false;
        }
    }
}
