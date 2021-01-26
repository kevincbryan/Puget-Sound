using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : Pool
{

    public Bullets()
    {
        poolName = "Bullets";
        minValue = 0f;
        maxValue = 6f;
        value = 6f;

    }

    public Bullets(float newBullets)
    {
        poolName = "Bullets";
        minValue = 0f;

        if (newBullets < minValue) newBullets += 1;

        maxValue = newBullets;
        value = newBullets;
    }


    public void Reload ()
    {
        base.Max();
    }

    public bool Fire ()
    {
        return (base.Spend(1f));
    }

    public bool Fire (float bullets)
    {
        bullets = Mathf.Abs(bullets);
        return (base.Spend(bullets));
    }

}
