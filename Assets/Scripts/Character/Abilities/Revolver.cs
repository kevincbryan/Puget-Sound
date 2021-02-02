using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Revolver", menuName = "Abilities/Revolver")]
public class Revolver : Ability
{
    [SerializeField] protected float damage = 5f;
    [SerializeField] protected float repDamage = 10f;



    
    private void OnEnable() 
    {
        Bullets mBullets = new Bullets();
        pools.Add(mBullets);
        costs.Add(1f);
            
        abilityName = "Revolver";
        description = "Shoot your gun to charge!";

    }

    public new bool Use (Entity user)
    {
        return (false);
    }

    public new bool Ready (Entity user)
    {
        if (user is Player)
        {
            Player pUser = (Player)user;
            Charge uCharge = pUser.charge;

            if (uCharge.Value >= pools[0].Value)
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
