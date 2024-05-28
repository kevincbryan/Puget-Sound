using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour
{
    [SerializeField] protected bool isHostile;
    [SerializeField] protected NeutralBehavior nBehavior = NeutralBehavior.Idle;
    [SerializeField] protected HostileBehavior hBehavior = HostileBehavior.Charge;
    [SerializeField] protected Character lastTarget;


    #region Accessors and Enums

    public bool IsHostile
    {
        get
        {
            return isHostile;
        }
    }

    public enum NeutralBehavior
    {
        Idle,
        Wander,
        Journey,
    };

    public enum HostileBehavior
    {
        Charge,
        Approach,
        Skirmish,
        Roar,
        Flee,
        Seek,
    };
    #endregion

    public void Hostile (bool input)
    {
        isHostile = input;
    }

    public void RandBehavior ()
    {
        RandHostile();
        RandNeutral();
    }

    public void RandHostile ()
    {
        hBehavior = (HostileBehavior)Random.Range(0, 5);
    }

    public void RandNeutral ()
    {
        nBehavior = (NeutralBehavior)Random.Range(0, 2);
    }

    public void SetHostileBehavior (HostileBehavior iHostile)
    {
        hBehavior = iHostile;
    }

    public void SetNeutralBehavior(HostileBehavior iNeutral)
    {
        hBehavior = iNeutral;
    }



    
  
}

