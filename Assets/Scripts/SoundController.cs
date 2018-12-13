using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public AudioClip diceHit;
    public AudioClip ground;

    // Bug Test: Changing pitch doesn't seem to have an effect
    public int pitch = 5;

    // Controls the speed the dice needs to hit another item at to emit sound
    public float velocity = 1f;
    AudioSource aSourceDice;
    AudioSource aSourceGround;

    private void Awake()
    {
        // Only one audiosource needed. Ok with dice emiting only 1 sound at a time
        aSourceDice = GetComponent<AudioSource>();
        aSourceGround = GetComponent<AudioSource>();

        aSourceDice.clip = diceHit;
        aSourceGround.clip = ground;
        aSourceDice.pitch = pitch;
    }

    // Checks for collision with another object. Used since collision can be used to 
    // check magnitiude of hit with object
    public void OnCollisionEnter(Collision collision)
    {
        // Only play if dice are going above a certain speed
        if (collision.relativeVelocity.magnitude > velocity)
        {
            switch (collision.gameObject.tag)
            {
                case "Ground":
                    AudioSource.PlayClipAtPoint(ground, transform.position);
                    break;

                // Check into multiple tag option for all dice to allivate needing so many cases
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
        }
    } // End OnCollisionEnter()

} // End class SoundController

// Dice Sound - tic.wav by fellur
// Ground - Knock_1.wav by Adam_N