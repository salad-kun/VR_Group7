using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SinkScript : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private AudioSource audioSource;
    private bool isActive;

    void Start()
    {
        // Find the Particle System on the child GameObject
        particleSystem = GetComponentInChildren<ParticleSystem>();
        // Get the Audio Source component on the same GameObject
        audioSource = GetComponent<AudioSource>();

        if (particleSystem == null)
        {
            Debug.LogError("Particle System not found on child GameObject!");
        }
        else
        {
            // Ensure the particle system is stopped at the start
            particleSystem.Stop();
        }

        if (audioSource == null)
        {
            Debug.LogError("Audio Source not found on the GameObject!");
        }

        isActive = false; // Start with effects inactive
    }

    // Call this method to activate both the particle system and audio source
    public void ToggleActivate()
    {
        if (particleSystem != null && audioSource != null)
        {
            if (isActive)
            {
                particleSystem.Stop();
                audioSource.Stop();
            }
            else
            {
                particleSystem.Play();
                audioSource.Play();
            }

            isActive = !isActive; // Toggle the state
        }
    }
}
