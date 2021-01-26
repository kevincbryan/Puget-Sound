using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : Pool
{
    
    public Charge ()
    {
        poolName = "Charge";
        minValue = 0f;
        maxValue = 5f;
        value = 0f;
       
    }

    public override void Yell()
    {
        Debug.Log("Charge yell has been called");
    }
}
