using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Death Laser", menuName = "Abilities/Death Laser")]

public class DeathLaser : Ability
{
    [SerializeField] protected float damage = 30f;
    [SerializeField] protected float repDamage = 5f;
    [SerializeField] protected float chargeCost = 5f;
    [SerializeField] protected float radius = 5f;
    [SerializeField] protected float range = 100f;
    private Transform direction;
    [SerializeField] protected float duration = 4f;
    [SerializeField] protected float launchForce = 10f;
    private float time;
    [SerializeField] protected GameObject particle;

    private void OnEnable() //Improvised Constructor for Scriptable Object
    {
        if (!runOnce)
        {
            abilityName = "Eye Beam Death Laser";
            description = "Blast your enemies with your eye lasers";
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
                Fire(pc);
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
                //Debug.Log("Fire should run?");
                //Fire(pc);
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
        //Debug.Log ("Claw Frenzy was fired");
        CoClock pClock = pc.gameObject.GetComponent<CoClock>();
        //Debug.Log("Fire has run");

        if (particle)
        {
            GameObject mParticles = Instantiate(particle, Camera.main.transform.position + (Camera.main.transform.forward * .5f), Camera.main.transform.rotation, Camera.main.transform);
            Destroy(mParticles, duration);
        }

        if (Input.GetButton("Fire2")) //Fire from Camera position if under direct camera control
        {
            direction = Camera.main.transform;
            time = 0f;
            //StartCoroutine(Laser());
            if (pClock) pClock.Run(Laser(pc));
        }
        else
        {
            direction = pc.transform;
            time = 0f;
            //StartCoroutine(Laser());
            if (pClock) pClock.Run(Laser(pc));
        }
    }

    IEnumerator Laser (PC pc)
    {
        //Debug.Log("Laser has been called");
        while (time <= duration)
        {
            time += Time.deltaTime;
            LaserFiring(pc);
            yield return null;
        }

        //Debug.Log("Ran out of time");

        yield return new WaitForSeconds(0f);
        Debug.Log("Laser is done");
    }

    private void LaserFiring (PC pc)
    {
        LayerMask pLayerMask = LayerMask.GetMask("Player");

        if (Input.GetButton("Fire2"))
        {
            direction = Camera.main.transform;

            Collider[] hitColliders = Physics.OverlapCapsule(direction.position, (direction.forward * range * 1f), radius, ~pLayerMask);
            foreach (var hitCollider in hitColliders)
            {
                //Debug.Log(hitCollider);
                if (Vector3.Distance(pc.transform.position, hitCollider.transform.position) <= range)
                {
                    //Debug.Log (hitCollider);
                    NPC hitEnemy = hitCollider.gameObject.GetComponent<NPC>();
                    if (hitEnemy)
                    {
                        //Debug.Log("Enemy hit with eyeLaser");
                        hitEnemy.entity.health.Damage(damage * Time.deltaTime); //damage it
                        hitEnemy.entity.faction.Hate(pc.entity.faction.Identity, repDamage * Time.deltaTime); // Make them hate us
                    }

                    Rigidbody rb = hitCollider.gameObject.GetComponent<Rigidbody>();
                    RigidSlow rbSlow = hitCollider.gameObject.GetComponent<RigidSlow>();

                    if (rb)
                    {

                        if (rbSlow)
                        {
                            rbSlow.NavOff();
                        }
                        rb.AddForce(pc.transform.forward * launchForce * Time.deltaTime, ForceMode.Impulse);
                        //rb.AddForce(pc.transform.up * launchForce * Time.deltaTime, ForceMode.Impulse);
                    }
                }
            }
            
        }
        else
        {
            direction = pc.transform;
            Collider[] hitColliders = Physics.OverlapCapsule(direction.position, (direction.forward * range * 1f), radius, ~pLayerMask);
            foreach (var hitCollider in hitColliders)
            {
                //Debug.Log(hitCollider);
                if (Vector3.Distance(pc.transform.position, hitCollider.transform.position) <= range)
                {
                    //Debug.Log (hitCollider);
                    NPC hitEnemy = hitCollider.gameObject.GetComponent<NPC>();
                    if (hitEnemy)
                    {
                        //Debug.Log("Enemy hit with eyeLaser");
                        hitEnemy.entity.health.Damage(damage * Time.deltaTime); //damage it
                    }

                    Rigidbody rb = hitCollider.gameObject.GetComponent<Rigidbody>();
                    RigidSlow rbSlow = hitCollider.gameObject.GetComponent<RigidSlow>();

                    if (rb)
                    {
                        if (rbSlow)
                        {
                            rbSlow.NavOff();
                        }
                        rb.AddForce(pc.transform.forward * launchForce * Time.deltaTime, ForceMode.Impulse);
                        //rb.AddForce(pc.transform.up * launchForce * Time.deltaTime, ForceMode.Impulse);
                    }
                }
            }
         
          
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
