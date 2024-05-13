using UnityEngine;

public class ItemSpinner : MonoBehaviour
{
    // Speed of rotation
    public float rotationSpeed = 50.0f;

    // Flag to indicate whether the item is on the socket
    private bool isOnSocket = false;

    // Reference to the socket GameObject
    private GameObject socket;

    void Start()
    {
        // Find the socket GameObject by tag
        socket = GameObject.FindGameObjectWithTag("Socket");
    }

    void Update()
    {
        // If the item is on the socket, rotate it around its local Y-axis
        if (isOnSocket)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    // Called when the item enters the socket's trigger collider
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == socket)
        {
            // Set the flag to indicate that the item is on the socket
            isOnSocket = true;
        }
    }

    // Called when the item exits the socket's trigger collider
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == socket)
        {
            // Reset the flag when the item leaves the socket
            isOnSocket = false;
        }
    }
}
