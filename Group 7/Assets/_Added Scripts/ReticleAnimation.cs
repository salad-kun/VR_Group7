using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleAnimation : MonoBehaviour
{
    public float scaleSpeed = 0.7f; // Speed of scaling
    public float maxScale = 1.5f; // Maximum scale of the reticle

    private Vector3 initialScale; // Initial scale of the reticle

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial scale of the reticle
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new scale based on sine wave
        float scaleFactor = Mathf.Sin(Time.time * scaleSpeed) * 0.2f + 0.2f;
        Vector3 newScale = initialScale * (1 + scaleFactor * maxScale);

        // Apply the new scale to the reticle
        transform.localScale = newScale;
    }
}
