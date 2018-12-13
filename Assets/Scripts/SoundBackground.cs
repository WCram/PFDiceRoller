using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBackground : MonoBehaviour {

    public AudioClip aCrowd;
    public AudioClip aSong;
    public float CrowdVolume = .4f;
    public float SongVolume = .1f;
    public bool PlayCrowd = true;
    public bool PlaySong = true;

    private AudioSource[] aSource;


	// Use this for initialization
	void Start () {

        // Pull all AudioSources
        aSource = GetComponents<AudioSource>();

        aSource[0].clip = aCrowd;
        aSource[0].loop = true;
        aSource[0].volume = CrowdVolume;
        if(PlayCrowd) aSource[0].Play();


        aSource[1].clip = aSong;
        aSource[1].loop = true;
        aSource[1].volume = SongVolume;
        if (PlaySong) aSource[1].Play();
    }

    // Update is called once per frame
    // Look into updating code with events
    // https://answers.unity.com/questions/1206632/trigger-event-on-variable-change.html
    void Update () {

        // Toggles Crowd on and off
        if (PlayCrowd && !aSource[0].isPlaying) aSource[0].Play();
        else if (!PlayCrowd) aSource[0].Stop();

        // Toggle Song on and off
        if (PlaySong && !aSource[1].isPlaying) aSource[1].Play();
        else if (!PlaySong) aSource[1].Stop();


        aSource[0].volume = CrowdVolume;
        aSource[1].volume = SongVolume;
    }

} // End class SoundBackground

// Song - "Medieval Introduction - Tristan Lohengrin
// Crowd -  Bar Crowd in Belgrade by EpicWizard 