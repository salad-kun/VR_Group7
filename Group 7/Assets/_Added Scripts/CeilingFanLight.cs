using UnityEngine;

public class CeilingFanLight : MonoBehaviour
{
    public Light[] ceilingLights;  // Array to hold multiple lights
    private bool isLightOn = false;  // Track the light state

    void Start()
    {
        if (ceilingLights != null && ceilingLights.Length > 0)
        {
            SetLightsState(isLightOn);  // Ensure all lights are off at the start
        }
        else
        {
            Debug.LogError("Ceiling Lights are not assigned.");
        }
    }

    public void ToggleLight()
    {
        isLightOn = !isLightOn;  // Toggle the state
        SetLightsState(isLightOn);
    }

    private void SetLightsState(bool state)
    {
        foreach (var light in ceilingLights)
        {
            if (light != null)
            {
                light.enabled = state;  // Update each light based on the new state
            }
        }
    }
}
