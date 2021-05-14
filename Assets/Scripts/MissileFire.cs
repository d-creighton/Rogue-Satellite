using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileFire : MonoBehaviour
{
    public GameObject missile;          // Missile to be fired
    public float force = 5f;            // Force of firing
    public float offset = 2f;           // Instantiation offset

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject m = Instantiate(missile, transform.position + transform.up * offset, transform.rotation);
            Rigidbody2D mrb = m.GetComponent<Rigidbody2D>();
            // Force forwards along local y axis
            mrb.AddRelativeForce(new Vector2(0, force), ForceMode2D.Impulse);
        }
    }
}
