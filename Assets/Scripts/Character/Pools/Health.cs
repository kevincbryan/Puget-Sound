using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Pool
{
    //public float healthOveride = 12f;
    private bool reflect = false;
    public delegate void Death();
    public static event Death Died;
    
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

        if (!reflect)
        {
            value -= damage;
        }
        else
        {
            value -= (damage/2);

        }
        
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


    public bool Damage(float damage, Entity source)  //subtract damage from value, if negative return true and run Die
    {

        if (!reflect)
        {
            value -= damage;
        }
        else
        {
            value -= (damage / 2);
            source.health.RetaliateDamage(damage / 2);

        }

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

    public bool RetaliateDamage(float damage)  //Damage which bypasses retaliate checks (call this when retaliating)
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

    public void Reflect (bool input)
    {
        reflect = input;
    }
    

    public void Heal (float healing) //add healing to value. Don't allow negative healings.
    {
        healing = Mathf.Abs(healing);

        value += healing;

        if (value >= maxValue) value = maxValue;
    }


    public virtual void Die () //Die is a virtual class so people can do different onDeath scripts
    {
       // Debug.Log("Health Die has been called");

        //if (Died != null) Died();
    }
}
