using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Reload", menuName = "Abilities/Reload")]
public class Reload : Ability
{

    private void OnEnable() //Improvised Constructor for Scriptable Object
    {
        if (!runOnce) //Runs only the first time
        {
            gcd = true;
            abilityName = "Reload";
            description = "Reload your gun";
            runOnce = true;
        }



    }

    

    public override bool Use(Entity user) //Checks if User is a Player and reloads bullets if true
    {
        //Debug.Log("Revolver is called");

        if (user is Player)
        {
            Player pUser = (Player)user;
            Bullets uBullets = pUser.bullets;
            
            uBullets.Max();
            return(true);
        }
        else
        {
            return (false);
        }
    }


    public override bool Ready(Entity user) //Checks if User is a Player and reloads bullets if true
    {
        //Debug.Log("Revolver ready has been called");
        if (user is Player)
        {
            return (true);
        }
        else
        {
            return (false);
        }


    }
}
