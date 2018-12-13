using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public AudioClip diceHit;
    public AudioClip ground;

    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {



    //} // End Update()

    public void OnTriggerEnter(Collider other)
    {
        
        switch(other.tag)
        {
            case "Ground":
                AudioSource.PlayClipAtPoint(ground, transform.position);

                break;
            case "d4":
            case "d6":
            case "d8":
            case "d10":
            case "d12":
            case "d20":
            case "d100":
                AudioSource.PlayClipAtPoint(diceHit, transform.position);
                break;
        }

    } // End OnTriggerEnter()

} // End class SoundController
