using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Revolver", menuName = "Abilities/Revolver")]
public class Revolver : Ability
{
    [SerializeField] protected float damage = 5f;
    [SerializeField] protected float repDamage = 10f;
    [SerializeField] protected float bulletCost = 1f;
    [SerializeField] float chargeGain = 1f;



    
    private void OnEnable() //Improvised Constructor for Scriptable Object
    {
      if (!runOnce) //Runs only the first time
      {
            abilityName = "Revolver";
            description = "Shoot your gun to charge!";
            runOnce = true;
      }
            
        

    }

    public override bool Use (Entity user) //Checks if User is a Player, if so tries to spend bullets and gain charge
    {
        //Debug.Log("Revolver is called");

        if (user is Player)
        {
            Player pUser = (Player)user;
            Bullets uBullets = pUser.bullets;
            //Debug.Log("Revolver is called and user is player");

            if (uBullets.Value >= 1)
            {
                uBullets.Spend(bulletCost);
                Charge uCharge = pUser.charge;
                uCharge.Add(chargeGain);
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

    public override bool Ready (Entity user) //Checks if User is a Player, checks if player has sufficient bullets to fire
    {
        //Debug.Log("Revolver ready has been called");
        if (user is Player)
        {
            Player pUser = (Player)user;
            Bullets uBullets = pUser.bullets;

            if (uBullets.Value >= bulletCost)
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
