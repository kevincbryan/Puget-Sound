using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Defense", menuName = "Abilities/Defense")]
public class Defense : Ability
{
    [SerializeField] protected float damage = 5f;
    [SerializeField] protected float repDamage = 5f;
    [SerializeField] protected float chargeCost = 1f;
    [SerializeField] protected float duration = 3f;
    private float time;
    [SerializeField] protected GameObject particle;

    private void OnEnable() //Improvised Constructor for Scriptable Object
    {
        if (!runOnce)
        {
            abilityName = "Vicious Defense";
            description = "Defend and Retaliate";
            runOnce = true;
        }
   
    }

    public override bool Use(PC pc)
    {
        if (pc.player is Player)
        {
            Player pUser = pc.player;
            Charge uCharge = pUser.charge;

            if (uCharge.Value >= chargeCost)
            {
                uCharge.Spend(chargeCost);
                Shield (pc);
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

    public override bool Ready(PC pc)
    {
        if (pc.player is Player)
        {
            Player pUser = pc.player;
            Charge uCharge = pUser.charge;

            if (uCharge.Value >= chargeCost)
            {
                //uCharge.Spend(chargeCost);
                //Shield (pc);
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

    private void Shield (PC pc)
    {
        if (pc.player is Player)
        {
            Health pHealth = pc.player.health;
            pHealth.Reflect(true);
            time = 0f;
            CoClock pClock = pc.gameObject.GetComponent<CoClock>();

            GameObject mParticles = Instantiate(particle, Camera.main.transform.position + (Camera.main.transform.forward * 1), Camera.main.transform.rotation, Camera.main.transform);


            if (pClock && mParticles)
            {
                //Debug.Log("pClock found + " + pClock);
                pClock.Run(UnShield(pHealth, mParticles));
            } 
            
        }
    }

    private IEnumerator UnShield (Health pHealth, GameObject particles)
    {
        while (time <= duration)
        {
            time += Time.deltaTime;
            //Debug.Log ("Running While");
            yield return null;
        }

        pHealth.Reflect(false);

        if (particles)
        {
            Destroy(particles);
        }
        Debug.Log ("Turned shield off");
        yield return new WaitForSeconds(0f);
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
