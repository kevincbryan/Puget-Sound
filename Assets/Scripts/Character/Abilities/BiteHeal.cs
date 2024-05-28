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
    [SerializeField] protected float range = 5f;
    [SerializeField] protected GameObject particle;

    private void OnEnable() //Improvised Constructor for Scriptable Object
    {
        if (!runOnce)
        {
            abilityName = "Bite";
            description = "Eat your enemies to heal!";
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
                bool didHit = Fire(pc);

                if (didHit)
                {
                    Health uHealth = pUser.health;
                    uHealth.Heal(healing);
                    //Debug.Log ("Healing user " + healing);
                }
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

    private bool Fire(PC pc)
    {
        LayerMask pLayerMask = LayerMask.GetMask("Player");
        bool didHit = false;

        if (particle)
        {
            GameObject mParticles = Instantiate(particle, Camera.main.transform.position + (Camera.main.transform.forward * .5f), Camera.main.transform.rotation, Camera.main.transform);
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
                    Debug.Log("Enemy hit with Bite Heal");
                    hitEnemy.entity.health.Damage(damage); //damage it
                    hitEnemy.entity.faction.Hate(pc.entity.faction.Identity, repDamage); // Make them hate us
                    didHit = true;
                }
            }
        }

        return (didHit);
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
