using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    protected string poolName;
    protected float minValue;
    protected float maxValue;
    protected float value;

    public float Value
    {
        get
        {
            return value;
        }
    }

    public string PoolName
    {
        get
        {
            return poolName;
        }
    }


    


    public Pool () //Constructor
    {
        poolName = "Pool";
        minValue = 0f;
        maxValue = 5f;
        value = 0f;
        
    }

    #region Pool Modifiers

        public float Add (float addAmount) //Add to pool return new value
        {
            value += addAmount;
            if (value > maxValue) value = maxValue;
            if (value < minValue) value = minValue;

            

            return (value);
        }

        public float Subtract(float subAmount) //Subtract from pool and return new value
        {
            value -= subAmount;
            if (value > maxValue) value = maxValue;
            if (value < minValue) value = minValue;

            

            return (value);
        }

        public float Min ()
        {
            value = minValue;
           

            return (value);
        }

        public float Max ()
        {
            value = maxValue;
           

            return(value);
        }

        public bool Has (float amount)
        {
            if (amount <= value)
            {
                return(true);
            }
            else
            {
                return(false);
            }
        }

        public bool Spend (float amount) //subtract amount only if the pool has that amount, returns true or false
        {
            if (amount <= value)
            {
                value -= amount;
                if (value > maxValue) value = maxValue;
                if (value < minValue) value = minValue;

               
                return (true);

            }
            else
            {
                return (false);
            }
        }

    #endregion

    public virtual void Yell ()
    {
        Debug.Log("Pool yell has been called");
    }

}
