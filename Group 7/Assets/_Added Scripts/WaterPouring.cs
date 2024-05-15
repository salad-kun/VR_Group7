using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPouring : MonoBehaviour
{
    public ParticleSystem waterParticleSystem;
    public float tiltThreshold = 45.0f; // Tilt angle in degrees to start pouring

    private Transform waterCanTransform;

    void Start()
    {
        if (waterParticleSystem == null)
        {
            Debug.LogError("Please assign a ParticleSystem to waterParticleSystem.");
            return;
        }

        waterCanTransform = this.transform;
    }

    void Update()
    {
        if (waterParticleSystem == null) return;

        // Calculate the angle between the water can's up vector and the world up vector
        float tiltAngle = Vector3.Angle(waterCanTransform.up, Vector3.up);

        if (tiltAngle > tiltThreshold)
        {
            if (!waterParticleSystem.isPlaying)
            {
                waterParticleSystem.Play();
            }
        }
        else
        {
            if (waterParticleSystem.isPlaying)
            {
                waterParticleSystem.Stop();
            }
        }
    }
}
