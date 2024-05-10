using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BouncyBallAudio : MonoBehaviour
{
    public AudioClip impactSound;
    private AudioSource audioSource;
    private Rigidbody rb;
    public float velocityThreshold = 0.5f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = impactSound;
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the magnitude of the relative velocity between the ball and the collision object exceeds the threshold
        if (collision.relativeVelocity.magnitude > velocityThreshold)
        {
            // Play the impact sound
            audioSource.PlayOneShot(impactSound, 0.7f);
        }
    }
}
