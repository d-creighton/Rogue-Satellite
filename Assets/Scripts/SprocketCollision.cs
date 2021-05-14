using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprocketCollision : MonoBehaviour
{
    public GameObject explosion;        // Explosion animation prefab

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if object is target
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get reference to target
            GameObject t = collision.gameObject;

            // Instantiate explosion at current position
            GameObject e = Instantiate(explosion, transform.position, Quaternion.identity);

            // Destroy explosion after short time
            Destroy(e, 0.25f);

            // Destroy sprocket
            Destroy(this.gameObject);

            // Destroy target
            GameObject.Destroy(t);
        }
    }
}
