using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLightSwtich : MonoBehaviour
{
    private bool isSwitchedOn = false;

    public void flipSwitch()
    {
        isSwitchedOn = !isSwitchedOn;

        if (isSwitchedOn )
        {
            transform.Rotate(Vector3.up, -15f); // Rotate 90 degrees when switched on
        }
        else
        {
            transform.Rotate(Vector3.up, 15f); // Rotate 90 degrees when switched on
        }
    }
}
