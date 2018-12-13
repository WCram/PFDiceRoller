using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSide : MonoBehaviour {

    // Flags when dice has landed on plane with "Ground" tag
    bool onGround;

    // The value of the dice
    public int sideValue;

    // Triggers when collider object, Sphere, makes contact with "Ground"
    void OnTriggerStay(Collider col)
    {

        if(col.tag == "Ground")
        {
            onGround = true;
        } // End if

    } // OnTriggerStay()

    // When collider leaves ground, sets flag to false
    private void OnTriggerExit(Collider col)
    {
        if(col.tag == "Ground")
        {
            onGround = false;
        }
    } // End OnTriggerExit()

    // Publicly accessible ground field
    public bool OnGround()
    {
        return onGround;
    } // End OnGround()


} // End class DiceSide
