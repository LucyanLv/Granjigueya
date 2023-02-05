using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillableBase : MonoBehaviour
{
    [SerializeField] private float maxFill;
    [SerializeField] private float actualFill;

    public float MaxFill { get => maxFill; set => maxFill = value; }
    public float ActualFill { get => actualFill; set => actualFill = value; }


    public void giveFill(float fill)
    {
        actualFill = actualFill -fill <= 0 ? 0 : actualFill - fill;
        //Debug.Log(actualFill);
    }

    public void recibeFill(float fill)
    {

        actualFill = actualFill + fill >= maxFill ? maxFill : actualFill + fill;
        Debug.Log($"tengo un actual de {ActualFill}" +
            $" y un maximo de {MaxFill} " +
            $"y me pueden llenar {FreeSpace()} y me esta llegando pa llenarme {fill}");
        actualFill += fill;

    }
    public float FreeSpace()
    {
        return MaxFill - ActualFill;
    }
}
