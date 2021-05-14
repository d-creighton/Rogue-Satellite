using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprocketControl : MonoBehaviour
{
    public GameObject sprocketPrefab;                   // Object to spawn
    public int directionValue = 0;                      // Random rotation value
    public float forceValue = 0.0f;                     // Random force value
    public float secondsBetween = 0.5f;                 // Time between spawns
    public float secondsSinceLast = 0.0f;               // Time since last spawn
    public float offset = 1.5f;                         // Spawn offset
    public float spinForce = 5.0f;                      // Torque

    private int generateDirection()
    {
        // Generate random direction in range 
        directionValue = Random.Range(135, 225);

        return directionValue;
    }

    private float generateForce()
    {
        // Generate random force in range 
        forceValue = Random.Range(0.25f, 3.0f);

        return forceValue;
    }

    // Update is called once per frame
    void Update()
    {
        // Add time since last call to update
        secondsSinceLast += Time.deltaTime;

        // If total time more than time between spawns
        if (secondsSinceLast >= secondsBetween)
        {
            // Direction generated
            generateDirection();
            
            // Spawn a new sprocket
            GameObject s = Instantiate(sprocketPrefab, transform.position + transform.up * offset, Quaternion.Euler(0, 0, directionValue));
            Rigidbody2D srb = s.GetComponent<Rigidbody2D>();

            // Force generated
            float force = generateForce();
            srb.AddRelativeForce(new Vector2(0, force), ForceMode2D.Impulse);

            // Add torque
            srb.AddTorque(spinForce);

            // Reset timer
            secondsSinceLast = 0;
        }
    }
}
