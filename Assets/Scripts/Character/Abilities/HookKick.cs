using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hook Kick", menuName = "Abilities/HookKick")]
public class HookKick : Ability
{
    [SerializeField] protected float damage = 10f;
    [SerializeField] protected float repDamage = 5f;
    [SerializeField] protected float chargeCost = 3f;
    [SerializeField] protected float range = 5f;
    [SerializeField] protected float launchForce = 10f;
    [SerializeField] protected GameObject particle;

    private void OnEnable() //Improvised Constructor for Scriptable Object
    {
        if (!runOnce)
        {
            abilityName = "Hook Kick";
            description = "Knock your enemies back!";
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

                
                Fire(pc);
                uCharge.Spend(chargeCost);
                return (true);
            }
            else
            {
                return(false);
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

    private void Fire(PC pc)
    {
        //RaycastHit hit;
        LayerMask pLayerMask = LayerMask.GetMask("Player");

        if (particle)
        {
            GameObject mParticles = Instantiate(particle, Camera.main.transform.position + (Camera.main.transform.up * -1f) + (Camera.main.transform.forward * .5f), Camera.main.transform.rotation);
            Destroy(mParticles, 2f);
        }
    

        Collider[] hitColliders = Physics.OverlapSphere(pc.transform.position + (pc.transform.forward * range * 1f), range, ~pLayerMask);
        foreach (var hitCollider in hitColliders)
        {
            //Debug.Log(hitCollider);
            if (Vector3.Distance(pc.transform.position, hitCollider.transform.position) <= range)
            {
                //Debug.Log (hitCollider);
                NPC hitEnemy = hitCollider.gameObject.GetComponent<NPC>();
                if (hitEnemy)
                {
                    Debug.Log("Enemy hit with Hook Kick");
                    hitEnemy.entity.health.Damage(damage); //damage it
                    hitEnemy.entity.faction.Hate(pc.entity.faction.Identity, repDamage); // Make them hate us
                }

                Rigidbody rb = hitCollider.gameObject.GetComponent<Rigidbody>();
                RigidSlow rbSlow = hitCollider.gameObject.GetComponent<RigidSlow>();

                if (rb)
                {

                    if (rbSlow)
                    {
                        rbSlow.NavOff();
                    }
                    rb.AddForce(pc.transform.forward * launchForce, ForceMode.Impulse);
                    rb.AddForce(pc.transform.up * launchForce, ForceMode.Impulse);
                }   

            }           
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
