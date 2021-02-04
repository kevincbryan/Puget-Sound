using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Defense", menuName = "Abilities/Defense")]
public class Defense : Ability
{
    [SerializeField] protected float damage = 5f;
    [SerializeField] protected float repDamage = 5f;
    [SerializeField] protected float chargeCost = 1f;

    private void OnEnable() //Improvised Constructor for Scriptable Object
    {
        if (!runOnce)
        {
            abilityName = "Vicious Defense";
            description = "Defend and Retaliate";
            runOnce = true;
        }

      

    }

    public override bool Use(Entity user) //Spend charge to gain Vicious Defense
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

    public override bool Ready(Entity user) //Check if user has enough charge to use Vicious Defense
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
