using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThankController : RefillableBase
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("wateringCan"))
        {
            RefillWaterCan(collision.gameObject.GetComponent<WateringCanController>());
        }
    }


    public void RefillWaterCan(WateringCanController can)
    {
        float fill = can.FreeSpace();
        can.recibeFill(fill);
        //this.giveFill(fill);
    }
}
