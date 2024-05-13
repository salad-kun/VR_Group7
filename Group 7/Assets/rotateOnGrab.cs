using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeOrientationOnGrab : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Quaternion initialRotation;

    void Start()
    {
        // Get reference to the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Store the initial rotation of the object
        initialRotation = transform.rotation;

        // Register the event handler for OnSelectEntered
        grabInteractable.onSelectEntered.AddListener(OnSelectEntered);
    }

    private void OnSelectEntered(XRBaseInteractor interactor)
    {
        // Change the orientation of the object when picked up
        // Example: Rotate the object 90 degrees around the X-axis
        transform.rotation = initialRotation * Quaternion.Euler(90, 0, 0);
    }
}
