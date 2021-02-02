using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{

    public PlayerHealth()
    {
        poolName = "Health";
        minValue = 0f;
        maxValue = 10f;
        value = maxValue;
    }

    public PlayerHealth(float newHealth)
    {
        poolName = "Health";
        minValue = 0f;

        if (newHealth < minValue) newHealth += 1;

        maxValue = newHealth;
        value = newHealth;
    }

    public override void Die()
    {
        Debug.Log("Player has died");
    }
}
