using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource music; //add audio source

    public AudioClip goodTrip; //adds new audio clip
    // Start is called before the first frame update
    private void Start()
    {
        music = GetComponent<AudioSource>();
    }

    public void ChangeSong() //changes the song 
    {
        music.clip = goodTrip; //chnages the clip
        music.volume = .1f; //changes the volume
        music.Play(); //plays the song
    }

}
