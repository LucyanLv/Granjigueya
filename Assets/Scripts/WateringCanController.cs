using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCanController : RefillableBase
{

    [SerializeField] private bool is_watering;
    Animator animationManager;


    private void Start()
    {
        animationManager = GetComponent<Animator>();

    }
    private void Update()
    {
        if (ActualFill > 0)
        {

            if (Input.GetMouseButtonDown(0))
            {
                animationManager.SetTrigger("starWatering");
            }
            if (Input.GetMouseButton(0))
            {
                giveFill(0.008f);
            }
            
        }
        if (Input.GetMouseButtonUp(0))
            {
                animationManager.SetTrigger("endWatering");
            }

    }

}
