using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCanController : RefillableBase
{

    [SerializeField] private bool is_watering;
    [SerializeField] private float delay;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log($" /////// {System.DateTime.Now}");
        }
        if (Input.GetMouseButton(0))
        {
            giveFill(0.008f);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log($" /////// {System.DateTime.Now}");
        }

    }


}
