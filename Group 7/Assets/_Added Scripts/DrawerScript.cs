using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class DrawerScript : MonoBehaviour
{
    public Transform drawer; // Reference to the drawer transform
    public float openDistance = 0.5f; // Distance the drawer should open
    public float speed = 2f; // Speed at which the drawer moves
    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpening = false;
    private bool isClosing = false;

    void Start()
    {
        if (drawer == null)
        {
            drawer = transform; // If no drawer assigned, use the object's transform
        }
        closedPosition = drawer.localPosition;
        openPosition = closedPosition + new Vector3(0, 0, openDistance);
    }

    void Update()
    {
        if (isOpening)
        {
            drawer.localPosition = Vector3.Lerp(drawer.localPosition, openPosition, Time.deltaTime * speed);
            if (Vector3.Distance(drawer.localPosition, openPosition) < 0.01f)
            {
                drawer.localPosition = openPosition;
                isOpening = false;
            }
        }
        else if (isClosing)
        {
            drawer.localPosition = Vector3.Lerp(drawer.localPosition, closedPosition, Time.deltaTime * speed);
            if (Vector3.Distance(drawer.localPosition, closedPosition) < 0.01f)
            {
                drawer.localPosition = closedPosition;
                isClosing = false;
            }
        }
    }

    public void ToggleDrawer()
    {
        if (!isOpening && !isClosing)
        {
            if (drawer.localPosition == closedPosition)
            {
                isOpening = true;
            }
            else if (drawer.localPosition == openPosition)
            {
                isClosing = true;
            }
        }
    }
}

