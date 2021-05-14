using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipControls : MonoBehaviour
{
    public float force = 1f;            // Forward movement force
    public float spinforce = 1f;        // Rotational force
    Rigidbody2D rb;                     // Object's rigidbody

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component of this object
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move up by applying positive force in y direction
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddRelativeForce(new Vector2(0, force));
        }
        // Spin clockwise on right arrow (negative torque)
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(-spinforce);
        }
        // Spin counterclockwise on left arrow (positive torque)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(spinforce);
        }
    }
}
