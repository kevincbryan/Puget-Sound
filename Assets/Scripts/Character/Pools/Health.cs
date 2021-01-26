using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Pool
{
    //public float healthOveride = 12f;
    
    public Health ()
    {
        poolName = "Health";
        minValue = 0f;
        maxValue = 10f;
        value = maxValue;
    }

    public Health (float newHealth)
    {
        poolName = "Health";
        minValue = 0f;

        if (newHealth < minValue) newHealth +=1;

        maxValue = newHealth;
        value = newHealth;
    }

    public bool Damage (float damage)  //subtract damage from value, if negative return true and run Die
    {
        value -= damage;
        if (value >= maxValue) value = maxValue;

        if (value <= minValue)
        {
            Die();
            return (true);
        }
        else
        {
            return (false);
        }
    }

    public void Heal (float healing) //add healing to value. Don't allow negative healings.
    {
        healing = Mathf.Abs(healing);

        value += healing;

        if (value <= maxValue) value = maxValue;
    }


    public virtual void Die () //Die is a virtual class so people can do different onDeath scripts
    {
        Debug.Log("Health Die has been called");
    }
}
