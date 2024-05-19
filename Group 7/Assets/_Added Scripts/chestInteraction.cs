using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChestInteraction : MonoBehaviour
{
    public Transform lid; // Reference to the lid transform
    public float openAngle = -90f; // The angle to rotate the lid to open it
    public float openSpeed = 2f; // The speed at which the lid opens
    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        // Store the initial rotation of the lid
        closedRotation = lid.localRotation;
        // Calculate the target open rotation
        openRotation = Quaternion.Euler(openAngle, 0, 0) * closedRotation;
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Toggle the chest open or close
        StopAllCoroutines(); // Stop any ongoing opening or closing animations
        if (isOpen)
        {
            StartCoroutine(CloseLid());
        }
        else
        {
            StartCoroutine(OpenLid());
        }
        isOpen = !isOpen;
    }

    private IEnumerator OpenLid()
    {
        float elapsedTime = 0;
        while (elapsedTime < 1)
        {
            lid.localRotation = Quaternion.Slerp(lid.localRotation, openRotation, elapsedTime);
            elapsedTime += Time.deltaTime * openSpeed;
            yield return null;
        }
        lid.localRotation = openRotation;
    }

    private IEnumerator CloseLid()
    {
        float elapsedTime = 0;
        while (elapsedTime < 1)
        {
            lid.localRotation = Quaternion.Slerp(lid.localRotation, closedRotation, elapsedTime);
            elapsedTime += Time.deltaTime * openSpeed;
            yield return null;
        }
        lid.localRotation = closedRotation;
    }
}



