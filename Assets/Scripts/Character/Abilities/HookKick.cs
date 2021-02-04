using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hook Kick", menuName = "Abilities/HookKick")]
public class HookKick : Ability
{
    [SerializeField] protected float damage = 10f;
    [SerializeField] protected float repDamage = 5f;
    [SerializeField] protected float chargeCost = 3f;

    private void OnEnable() //Improvised Constructor for Scriptable Object
    {
        if (!runOnce)
        {
            abilityName = "Hook Kick";
            description = "Knock your enemies back!";
            runOnce = true;
        }
    }

    public override bool Use(Entity user) //Spend charge to gain Hook Kick
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

    public override bool Ready(Entity user) //Check if user has enough charge to use Hook Kick
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
