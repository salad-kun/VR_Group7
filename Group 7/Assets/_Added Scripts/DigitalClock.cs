using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DigitalClock : MonoBehaviour
{
    // show time on clock (unity)
    public GameObject hourHand;
    public GameObject minuteHand;
    public GameObject secondHand;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        System.DateTime now = System.DateTime.Now;

        // Calculate the rotation for each hand
        float hourRotation = (now.Hour % 12) * 30 + (now.Minute / 2f); // 360 degrees / 12 hours = 30 degrees per hour + half of the minute rotation
        float minuteRotation = now.Minute * 6; // 360 degrees / 60 minutes = 6 degrees per minute
        float secondRotation = now.Second * 6; // 360 degrees / 60 seconds = 6 degrees per seconds

        // Set the rotation for the hour hand
        // Note: Clock hands rotate around x-axis. 
        // 0 degrees points up. leave all other axes at 0. 
        hourHand.transform.rotation = Quaternion.Euler(hourRotation, 0, 0);

        // Set the rotation for the minute hand
        minuteHand.transform.rotation = Quaternion.Euler(minuteRotation, 0, 0);

        // Set the rotation for the second hand
        secondHand.transform.rotation = Quaternion.Euler(secondRotation, 0, 0);
    }
}
