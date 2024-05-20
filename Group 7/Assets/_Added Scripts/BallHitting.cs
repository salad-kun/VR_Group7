using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHitting : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Racket"))
        {
            // Apply force to the ball based on the collision impact
            Vector3 force = collision.relativeVelocity * 0.5f; // Adjust the multiplier as needed
            rb.AddForce(force, ForceMode.Impulse);
        }
    }
}
