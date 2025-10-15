using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    //[SerializeField]
    //GameObject secondsHand;

    //[SerializeField]
    //GameObject minutesHand;

    //[SerializeField]
    //GameObject hoursHand;

    //[SerializeField]
    //float secondsSpeed = 0.25f;

    //public bool smoothMovement = false;

    public Transform hoursHand;
    public Transform minutesHand;
    public Transform secondsHand;

    // Update is called once per frame
    void Update()
    {
        //// Set the hands of the current time
        //DateTime dt = DateTime.Now;
        //Debug.Log("Time: " + dt.TimeOfDay);

        //// Get the seconds
        //int seconds = dt.Second;
        //float secDegree = -(seconds / 60f) * 360;

        //// Get the minutes
        //int minutes = dt.Minute;
        //// Convert minutes to degrees
        //float minDegree = -(minutes / 60f) * 360;

        //// Get the hours
        //int hours = dt.Hour;
        //// Convert hours to degrees
        //float hourDegree = -(hours / 24f) * 360;

        //if (smoothMovement)
        //{
        //    secDegree = Mathf.LerpAngle(secondsHands.transform.localRotation.eulerAngles.z, secDegree, Time.deltaTime * secondsSpeed);
        //    minDegree = Mathf.LerpAngle(minutesHands.transform.localRotation.eulerAngles.z, minDegree, Time.deltaTime);
        //    hourDegree = Mathf.LerpAngle(hoursHands.transform.localRotation.eulerAngles.z, hourDegree, Time.deltaTime);
        //}

        //secondsHands.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, secDegree));
        //minutesHands.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, minDegree));
        //hoursHands.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, hourDegree));

        //DateTime currenTime = DateTime.Now;

        //float secondsDegree = -(currenTime.Second / 60f) * 360f;
        //secondsHand.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, secondsDegree));

        //float minutesDegree = -(currenTime.Minute / 60f) * 360f;
        //minutesHand.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, minutesDegree));

        //float hoursDegree = -(currenTime.Hour / 24f) * 360f;
        //hoursHand.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, hoursDegree));

        DateTime currentTime = DateTime.Now;

        // Calculate rotation angles;
        float hoursAngle = (currentTime.Hour % 12) * 30f + currentTime.Minute * 0.5f; // 30° per hour
        float minutesAngle = currentTime.Minute * 6f; // 6° per minute
        float secondsAngle = currentTime.Second * 6f; // 6° per second

        // Rotate the clock hands
        hoursHand.localRotation = Quaternion.Euler(-hoursAngle, 0f, 0f);
        minutesHand.localRotation = Quaternion.Euler(-minutesAngle, 0f, 0f);
        secondsHand.localRotation = Quaternion.Euler(-secondsAngle, 0f, 0f);
    }
}
