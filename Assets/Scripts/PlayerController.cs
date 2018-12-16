using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // How often the accelerometer checks for change in location
    float accelerometerUpdateInterval = 1.0f / 60.0f;

    // The greater the value of LowPassKernelWidthInSeconds, the slower the
    // filtered value will converge towards current input sample (and vice versa).
    float lowPassKernelWidthInSeconds = 1.0f;

    // This next parameter is initialized to 2.0 per Apple's recommendation
    float shakeDetectionThreshold = 2.0f;

    float lowPassFilterFactor;
    Vector3 lowPassValue;

    // Unity Object
    public Rigidbody rb;
    public float speed;

    // Gets value of dice after landing
    bool hasLanded;
    bool thrown;

    public int diceValue;

    public DiceSide[] diceSides;
    DiceSpawn ds;


    void Start()
    {
        ds = new DiceSpawn();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowPassValue = Input.acceleration;
        rb = GetComponent<Rigidbody>();

    } // End Start()

    // Runs 30 times a second
    void Update()
    {
        // Gets acceleration from accelerometer (distance between current and previous location)
        Vector3 acceleration = Input.acceleration;
        lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
        Vector3 deltaAcceleration = acceleration - lowPassValue;

        // If the movment of the phone was greater than a certain magnitude of speed then execute
        if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
        {
            // Speed influences the amount of impact imparted upon dice
            float x = deltaAcceleration.x * speed;
            float y = deltaAcceleration.y * speed;
            float z = deltaAcceleration.z * speed;
            thrown = true;
            hasLanded = false;
            diceValue = 0;

            // Passes accelerometer values * speed into rigidbody
            // Utilizing ForceMode.Impulse treats it like an external impact to the dice
            rb.AddForce(new Vector3(-x, y, z), ForceMode.Impulse);
        }



        // Checks value of dice only have the dice have been thrown, landed on "Ground", and have stopped moving
        if (rb.IsSleeping() && !hasLanded && thrown)
        {
            hasLanded = true;
            thrown = false;

            SideValueCheck();

        }

    } // End Update()

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "OutOfBounds")
        {
            transform.position = new Vector3(0,0,21.5f);
        }

    } // End OnTriggerEnter

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(ds.DiceCount().ToString());
        if(collision.gameObject.layer == 9)
        {
            Physics.IgnoreLayerCollision(9,9);
        }
    }

    // Returns the value of the current rigidBody dice side
    void SideValueCheck()
    {

        diceValue = 0;
        foreach (DiceSide side in diceSides)
        {

            if (side.OnGround())
            {
                diceValue = side.sideValue;
            }

        } // End foreach

    } // End void SideValueCheck()

}
