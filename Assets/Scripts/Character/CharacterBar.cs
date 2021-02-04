using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBar : MonoBehaviour
{
    public Ability chargeAbility;
    public Ability firstAbility;
    public Ability secondAbility;
    public Ability thirdAbility;
    public Ability fourthAbility;
    public Ability fifthAbility;

    private float globalTime;
    [SerializeField] private float coolDownTime = 50f;
    [SerializeField] private bool gcdReady = true;

    public PC pc;

#region Accessors
    public bool GCDReady
    {
        get
        {
            return (gcdReady);
        }
    }

#endregion

    private void Update() 
    {
        UpdateGCD();

        
        CheckCharge();
        
    }

#region GCD
    private void UpdateGCD()
    {
        globalTime += Time.deltaTime;
        if (globalTime >= coolDownTime && gcdReady == false)
        {
            //Debug.Log(globalTime);
            gcdReady = true;
            //Debug.Log(gcdReady);
            //Debug.Log("GCD has been set to " + gcdReady);
        } 
    }

    private void ResetGCD()
    {
        //Debug.Log ("Reset has been called");
        globalTime = 0;
        gcdReady = false;
        Debug.Log(gcdReady);
       
    }

#endregion

    private void CheckCharge()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Revolver attempted, Bullets: " + pc.player.bullets.Value +  "Charge amount: " + pc.player.charge.Value);
            if (gcdReady || chargeAbility.GCD == false)
            {
                //Debug.Log(chargeAbility.Ready(pc.player));
                //Debug.Log(pc.player.bullets.Value);
            
                if (chargeAbility.Use(pc.player))
                {
                    Debug.Log("Revolver fired, Bullets: " + pc.player.bullets.Value + "Charge amount: " + pc.player.charge.Value);

                    if (chargeAbility.GCD) ResetGCD();
                    
                }
                else
                {
                    //Debug.Log("Revolver failed, Bullets: " + pc.player.bullets.Value + "Charge amount: " + pc.player.charge.Value);
                    //failure condition here
                }
            }
            else
            {
                
                //failure condition here
            }
        }
    }

}
