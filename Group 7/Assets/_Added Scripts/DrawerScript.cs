using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class DrawerScript : MonoBehaviour
{
    public Transform drawer;
    public float openDistance = 0.5f;
    public float speed = 2f;
    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpening = false;
    private bool isClosing = false;

    void Start()
    {
        if (drawer == null)
        {
            drawer = transform;
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

