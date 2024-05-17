using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CD : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation
    private bool isOnRecordPlayer = false; // Flag to check if the CD is on the record player

    void Update()
    {
        // If the CD is on the record player, rotate it
        if (isOnRecordPlayer)
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the CD has collided with the record player
        if (other.CompareTag("recordSocket"))
        {
            isOnRecordPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the CD has exited the record player
        if (other.CompareTag("recordSocket"))
        {
            isOnRecordPlayer = false;
        }
    }
}
