using UnityEngine;

public class RotateToAngle : MonoBehaviour
{
    public GameObject item; // The item you want to rotate
    public Vector3 sideOffset; // Offset for the new pivot point
    public Vector3 targetRotation; // Desired rotation as Euler angles (in degrees)
    public float rotationSpeed = 100.0f; // Speed of rotation

    private GameObject pivotObject; // The new pivot object
    private Quaternion initialRotation; // Initial rotation of the item
    private Quaternion targetQuaternion; // Target rotation in Quaternion
    private Quaternion resetQuaternion; // Quaternion for the reset rotation (0, 0, 0)
    private bool isRotating = false; // Flag to start/stop rotation
    private bool resetRotation = false; // Flag to start/stop resetting rotation

    void Start()
    {
        // Create an empty GameObject as the new pivot point
        pivotObject = new GameObject("PivotObject");

        // Position the pivot object at the side of the item
        pivotObject.transform.position = item.transform.position + sideOffset;

        // Parent the item to the pivot object
        item.transform.SetParent(pivotObject.transform);

        // Optionally, reset the item's local position relative to the pivot object
        item.transform.localPosition = -sideOffset;

        // Calculate the initial rotation and target rotation in Quaternion
        initialRotation = pivotObject.transform.rotation;
        targetQuaternion = Quaternion.Euler(targetRotation);
        resetQuaternion = Quaternion.Euler(Vector3.zero);
    }

    void Update()
    {
        if (isRotating)
        {
            // Smoothly rotate towards the target rotation
            pivotObject.transform.rotation = Quaternion.RotateTowards(
                pivotObject.transform.rotation,
                targetQuaternion,
                rotationSpeed * Time.deltaTime
            );

            // Check if the rotation is close enough to the target rotation
            if (Quaternion.Angle(pivotObject.transform.rotation, targetQuaternion) < 0.1f)
            {
                // Snap to the target rotation and stop rotating
                pivotObject.transform.rotation = targetQuaternion;
                isRotating = false;
            }
        }

        if (resetRotation)
        {
            // Smoothly rotate towards the initial rotation
            pivotObject.transform.rotation = Quaternion.RotateTowards(
                pivotObject.transform.rotation,
                resetQuaternion,
                rotationSpeed * Time.deltaTime
            );

            // Check if the rotation is close enough to the initial rotation
            if (Quaternion.Angle(pivotObject.transform.rotation, resetQuaternion) < 0.1f)
            {
                // Snap to the initial rotation and stop resetting rotation
                pivotObject.transform.rotation = resetQuaternion;
                resetRotation = false;
            }
        }
    }

    // Public method to trigger the rotation to target
    public void StartRotation()
    {
        isRotating = true;
        resetRotation = false;
    }

    // Public method to trigger the rotation back to initial rotation
    public void StopRotation()
    {
        resetRotation = true;
        isRotating = false;
    }
}

