using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public AudioClip diceHit;
    public AudioClip ground;
    public int pitch = 5;
    public float velocity = 1f;
    AudioSource aSourceDice;
    AudioSource aSourceGround;

    private void Awake()
    {
        aSourceDice = GetComponent<AudioSource>();
        aSourceGround = GetComponent<AudioSource>();

        aSourceDice.clip = diceHit;
        aSourceGround.clip = ground;
        aSourceDice.pitch = pitch;
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > velocity)
        {
            switch (collision.gameObject.tag)
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
        }
    } // End OnCollisionEnter()

} // End class SoundController
