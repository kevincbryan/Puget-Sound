using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Bite Heal", menuName = "Abilities/BiteHeal")]
public class BiteHeal : Ability
{

    [SerializeField] protected float damage = 10f;
    [SerializeField] protected float repDamage = 5f;
    [SerializeField] protected float healing = 10f;
    [SerializeField] protected float chargeCost = 4f;

    private void OnEnable() //Improvised Constructor for Scriptable Object
    {
        if (!runOnce)
        {
            abilityName = "Bite";
            description = "Eat your enemies to heal!";
            runOnce = true;
        }
    }

    public override bool Use(Entity user) //Spend charge to gain Bite
    {
        if (user is Player)
        {
            Player pUser = (Player)user;
            Charge uCharge = pUser.charge;
            if (uCharge.Value >= chargeCost)
            {
                uCharge.Spend(chargeCost);
                Health uHealth = pUser.health;
                uHealth.Heal(healing);
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

    public override bool Ready(Entity user) //Check if user has enough charge to use Bite
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
