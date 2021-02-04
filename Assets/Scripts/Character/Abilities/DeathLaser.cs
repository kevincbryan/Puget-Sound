using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Death Laser", menuName = "Abilities/Death Laser")]

public class DeathLaser : Ability
{
    [SerializeField] protected float damage = 30f;
    [SerializeField] protected float repDamage = 5f;
    [SerializeField] protected float chargeCost = 5f;

    private void OnEnable() //Improvised Constructor for Scriptable Object
    {
        if (!runOnce)
        {
            abilityName = "Eye Beam Death Laser";
            description = "Blast your enemies with your eye lasers";
            runOnce = true;
        }
    }

    public override bool Use(Entity user) //Spend charge to gain Death Laser
    {
        if (user is Player)
        {
            Player pUser = (Player)user;
            Charge uCharge = pUser.charge;
            if (uCharge.Value >= chargeCost)
            {
                uCharge.Spend(chargeCost);
                return (true);
            }
            else
            {
                return (false);
            }
        }
        else
        {
            return (false);
        }
    }

    public override bool Ready(Entity user) //Check if user has enough charge to use Death Laser
    {
        if (user is Player)
        {
            Player pUser = (Player)user;
            Charge uCharge = pUser.charge;

            if (uCharge.Value >= chargeCost)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        else
        {
            return (false);

        }
    }
}
