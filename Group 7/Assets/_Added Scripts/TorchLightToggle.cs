using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TorchLightToggle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Ensure the torchlight is off at the start
        gameObject.SetActive(false);
    }

    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
