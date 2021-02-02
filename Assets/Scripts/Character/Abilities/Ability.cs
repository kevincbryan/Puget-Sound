using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName = "Ability", menuName = "Abilities/Default")]
public class Ability : ScriptableObject
{
   [SerializeField] protected string abilityName;
   [SerializeField] protected string description;
     
   [SerializeField] protected bool gcd;
   [SerializeField] protected List <Pool> pools = new List<Pool>(0);
   [SerializeField] protected List <float> costs = new List<float>(0);

private void OnEnable() 
{
    //Debug.Log("Default enable has been called");
    //pools.Add(new Bullets());
    //Bullets mBullets = new Bullets();
    //pools.Add(mBullets);
    //costs.Add(1f);
}

#region accessors
    public string Name
    {
        get
        {
            return abilityName;
        }
    }

    public bool GCD
    {
        get
        {
            return gcd;
        }
    }

    public string Description
    {
        get 
        {
            return description;
        }
        
    }
    #endregion

    public virtual bool Use() //Virtual to set up for use functions
    {
        return (false);
    }

    public virtual bool Use(Entity user) //Virtual to set up for use functions
    {
        return (false);
    }

    public virtual bool Ready() //Virtual to check if ability is usable
    {
        return (false);
    }

    public virtual bool Ready(Entity user) //Virtual to check if ability is usable
    {
        return (false);
    }
   


}
