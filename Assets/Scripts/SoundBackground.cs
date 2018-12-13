using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBackground : MonoBehaviour {

    public AudioClip aCrowd;
    public AudioClip aSong;
    public float CrowdVolume = .4f;
    public float SongVolume = .1f;

    private AudioSource[] aSource;


	// Use this for initialization
	void Start () {
        aSource = GetComponents<AudioSource>();


        aSource[0].clip = aCrowd;
        aSource[0].loop = true;
        aSource[0].volume = CrowdVolume;
        aSource[0].Play();

        aSource[1].clip = aSong;
        aSource[1].loop = true;
        aSource[1].volume = SongVolume;
        aSource[1].Play();

        //AudioSource.PlayClipAtPoint(aSong, transform.position);
    }
	
	// Update is called once per frame
	void Update () {
        aSource[0].volume = CrowdVolume;
        aSource[1].volume = SongVolume;
    }

} // End class SoundBackground

// Song - "Medieval Introduction - Tristan Lohengrin
// Crowd -  Bar Crowd in Belgrade by EpicWizard 