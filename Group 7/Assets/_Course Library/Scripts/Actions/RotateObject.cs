using UnityEngine;

/// <summary>
/// Set the rotation of an object
/// </summary>
public class RotateObject : MonoBehaviour
{
    [Tooltip("The value at which the speed is applied")]
    [Range(0, 1)] public float sensitivity = 1.0f;

    [Tooltip("The max speed of the rotation")]
    public float speed = 10.0f;
    public float currentSpeed = 0.0f;

    private bool isRotating = false;

    public void SetIsRotating(bool value)
    {
        if(value)
        {
            Begin();
        }
        else
        {
            End();
        }
    }

    public void Begin()
    {
        isRotating = true;
    }

    public void End()
    {
        isRotating = false;
    }

    public void ToggleRotate()
    {
        isRotating = !isRotating;
    }


    public void SetSpeed(float value)
    {
        sensitivity = Mathf.Clamp(value, 0, 1);
        isRotating = (sensitivity * speed) != 0.0f;
    }

    private void Update()
    {
        if (isRotating)
            RotateFast();
        else
            RotateSlow();
    }

    private void RotateFast()
    {
        // Gradually increase the current speed towards the target speed
        currentSpeed = Mathf.MoveTowards(currentSpeed, speed, Time.deltaTime * 50f);

        transform.Rotate(transform.up, (sensitivity * currentSpeed) * Time.deltaTime);
    }

    private void RotateSlow()
    {
        // Gradually increase the current speed towards the target speed
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0, Time.deltaTime * 50f);

        transform.Rotate(transform.up, (sensitivity * currentSpeed) * Time.deltaTime);
    }
}
