using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCabinetDoor : MonoBehaviour
{
    private bool isTouched = false;
    [SerializeField] private float angle = 90f;

    public void toggleDoor()
    {
        isTouched = !isTouched;

        if (isTouched)
        {
            transform.Rotate(Vector3.up, angle); // Rotate 90 degrees when switched on
        }
        else
        {
            transform.Rotate(Vector3.up, -angle); // Rotate 90 degrees when switched on
        }
    }
}
