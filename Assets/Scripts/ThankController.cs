using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThankController : RefillableBase
{
    Animator animationManager;

    private void Start()
    {
        animationManager = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("wateringCan"))
        {
            animationManager.SetBool("canFill", true);
            RefillWaterCan(collision.gameObject.GetComponent<WateringCanController>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animationManager.SetBool("canFill", false);
    }


    public void RefillWaterCan(WateringCanController can)
    {
        float fill = can.FreeSpace();
        can.recibeFill(fill);
        //this.giveFill(fill);
    }
}
