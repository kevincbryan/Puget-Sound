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
    [SerializeField] float range = 50f;
    [SerializeField] GameObject particle;
    [SerializeField] GameObject impactBlood;
    [SerializeField] GameObject bullet;
    //private int pMask = 1 << 8;



    
    private void OnEnable() //Improvised Constructor for Scriptable Object
    {
      if (!runOnce) //Runs only the first time
      {
            abilityName = "Revolver";
            description = "Shoot your gun to charge!";
            runOnce = true;
            //pMask = LayerMask.GetMask("Player");
            //pMask = ~pMask;
      }
            
        

    }


    public override bool Use (PC pc)  //version of use that includes PC transform data
    {
        //Debug.Log(pc.transform);


        if (pc.player is Player)
        {
            Player pUser = pc.player;
            Bullets uBullets = pUser.bullets;
            //Debug.Log("Revolver is called and user is player");

            if (uBullets.Value >= 1)
            {
                uBullets.Spend(bulletCost);
                Charge uCharge = pUser.charge;
                uCharge.Add(chargeGain);

                Fire (pc);
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

    public void Strike (Entity enemy, Collision colInfo, PC pc)
    {
        enemy.health.Damage(damage);
        enemy.faction.Hate(pc.entity.faction.Identity, repDamage);
        Debug.Log(enemy + " hit!");
        if (impactBlood)
        {
            Quaternion angle;
            angle = Quaternion.Euler(colInfo.GetContact(0).normal);
            GameObject mParticles = Instantiate(impactBlood, colInfo.GetContact(0).point, angle, colInfo.transform);
            Destroy(mParticles, 2f);
        }
    }

    private void Fire (PC pc) //Attempts to damage first object in raycast, from either camera or player position
    {
        RaycastHit hit;
        LayerMask pLayerMask = LayerMask.GetMask("Player");

        if (Input.GetButton("Fire2")) //Fire from Camera position if under direct camera control
        {
            
            if (bullet)
            {
                GameObject mBullet = Instantiate(bullet, Camera.main.transform.position + (Camera.main.transform.forward * .5f), Camera.main.transform.rotation);
                RevolverBullet mRevolverBullet = mBullet.GetComponent<RevolverBullet>();
                if (mRevolverBullet)
                {
                    mRevolverBullet.sFaction = pc.entity.faction;
                    mRevolverBullet.pc = pc;
                    mRevolverBullet.sourceAbility = this; 
                }
            }
            
            /*
            if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, range, ~pLayerMask)) //if directly controlling camera, fire from camera position and angle
            {
                NPC hitEnemy = hit.transform.gameObject.GetComponent<NPC>();

                if (particle)
                {
                    GameObject mParticles = Instantiate(particle, Camera.main.transform.position + Camera.main.transform.forward * .3f + Camera.main.transform.right * .1f, Camera.main.transform.rotation);
                    Destroy(mParticles, 2f);
                }
                
                if (hitEnemy) //if you shoot a health possessing enemy
                {
                    Debug.Log("Enemy hit");
                    hitEnemy.entity.health.Damage(damage); //damage it
                    hitEnemy.entity.faction.Hate(pc.entity.faction.Identity, repDamage); // Make them hate us


                    if (impactBlood)
                    {
                        Quaternion angle;
                        angle = Quaternion.Euler(hit.normal);
                        GameObject mParticles = Instantiate(impactBlood, hit.point, angle, hitEnemy.transform);
                        Destroy(mParticles, 2f);
                    }
                }
            }
            */
        }
        else
        {
            Vector3 mousePos =(Input.mousePosition);
            mousePos.z = Camera.main.nearClipPlane;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector3 direction = (mousePos - Camera.main.transform.position);
            //Debug.Log(Input.mousePosition);
            //Debug.Log(direction);
            direction = Vector3.Normalize(direction);

            //Debug.Log ("direction  is " + direction + " camera main direction is " + Camera.main.transform.forward);
            //Debug.DrawRay (Camera.main.transform.position, direction * range, Color.white, 100f);

            //Debug.Log("Direction is " + direction);

            //Debug.Log ("Quaternion is " + Quaternion.Euler(direction));

            //Quaternion look = Quaternion.LookRotation (direction);
            


            if (bullet)
            {
                GameObject mBullet = Instantiate(bullet, Camera.main.transform.position + (Camera.main.transform.forward * .5f), Quaternion.LookRotation(direction));
                RevolverBullet mRevolverBullet = mBullet.GetComponent<RevolverBullet>();
                if (mRevolverBullet)
                {
                    mRevolverBullet.sFaction = pc.entity.faction;
                    mRevolverBullet.pc = pc;
                    mRevolverBullet.sourceAbility = this;
                }
            }
            
            /*
            if (Physics.Raycast (Camera.main.transform.position, direction, out hit, range, ~pLayerMask ))
            {
                //Debug.Log ("Hit " + hit.transform.gameObject + " at location " + hit.transform.position);
                NPC hitEnemy = hit.transform.gameObject.GetComponent<NPC>();


                if (particle)
                {
                    GameObject mParticles = Instantiate(particle, Camera.main.transform.position + Camera.main.transform.forward * .3f + Camera.main.transform.right * .1f, Camera.main.transform.rotation);
                    Destroy(mParticles, 2f);
                }

                if (hitEnemy) //if you shoot a health possessing enemy
                {
                    //Debug.Log("Enemy hit");
                    hitEnemy.entity.health.Damage(damage); //damage it
                    hitEnemy.entity.faction.Hate(pc.entity.faction.Identity, repDamage); // Make them hate us


                    if (impactBlood)
                    {
                        Quaternion angle;
                        angle = Quaternion.Euler (hit.normal);
                        //Debug.Log (hit.normal);
                        GameObject mParticles = Instantiate(impactBlood, hit.point, angle, hitEnemy.transform);
                        Destroy(mParticles, 2f);
                    }
                }
            }
            */
        }
    }



    public override bool Ready(PC pc) //version of Ready that includes PC transform data
    {
        //Debug.Log("Revolver ready has been called");
        if (pc.player is Player)
        {
            Player pUser = pc.player;
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
