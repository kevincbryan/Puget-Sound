using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterBar : MonoBehaviour
{
    public Ability chargeAbility;
    public Ability firstAbility;
    public Ability secondAbility;
    public Ability thirdAbility;
    public Ability fourthAbility;
    public Ability fifthAbility;
    public Ability reloadAbility;

    [SerializeField] public ActionBarUI [] pActionBar;

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


    void Start ()
    {
        //eventSys = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }
    private void Update() 
    {
        UpdateGCD();
        CheckCharge();
        CheckReload();
        CheckFirst();
        CheckSecond();
        CheckThird();
        CheckFourth();
        CheckFifth();
        
    }

    private void UpdateUI()
    {
        //Update whether the UI says things are affordable
        if (pActionBar.Length >= 5)
        {

            if (pc.player is Player)
            {
                Player mPlayer = pc.player;
                pActionBar[0].isCastable(mPlayer.charge.Value >= 1);
                pActionBar[1].isCastable(mPlayer.charge.Value >= 2);
                pActionBar[2].isCastable(mPlayer.charge.Value >= 3);
                pActionBar[3].isCastable(mPlayer.charge.Value >= 4);
                pActionBar[4].isCastable(mPlayer.charge.Value >= 5);
            }
            
        }
      

        
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

#region CheckFunctions

    private void CheckCharge ()
    {
        if (Input.GetButtonDown("Fire1") && (!EventSystem.current.IsPointerOverGameObject()))
        {
            UseCharge();
        }
    }

    private void CheckReload()
    {
        if (Input.GetButtonDown("Reload"))
        {
            UseReload();
        }
    }

    private void CheckFirst()
    {
        if (Input.GetButtonDown("Action1"))
        {
            UseFirst();
        }
    }

    private void CheckSecond()
    {
        if (Input.GetButtonDown("Action2"))
        {
            UseSecond();
        }
    }

    private void CheckThird()
    {
        if (Input.GetButtonDown("Action3"))
        {
            UseThird();
        }
    }


    private void CheckFourth()
    {
        if (Input.GetButtonDown("Action4"))
        {
            UseFourth();
        }
    }


    private void CheckFifth()
    {
        if (Input.GetButtonDown("Action5"))
        {
            UseFifth();
        }
    }






#endregion

#region UseFunctions

    public void UseCharge()
    {
       

            if (pc.player.bullets.Value == 0 && gcdReady)
            {
                if (reloadAbility.Use (pc.player))
                {
                    //Debug.Log ("Reloading, bullet amount is: " + pc.player.bullets.Value);
                }
                else
                {
                    //failure state
                }
            }
            else if (gcdReady || chargeAbility.GCD == false)
            {
                //Debug.Log(chargeAbility.Ready(pc.player));
                //Debug.Log(pc.player.bullets.Value);
            
                if (chargeAbility.Use(pc))
                {
                    //Debug.Log("Revolver fired, Bullets: " + pc.player.bullets.Value + "Charge amount: " + pc.player.charge.Value);

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

        UpdateUI();
        
    }

    public void UseReload()
    {

       
            //Debug.Log ("Reload has been called");
            if (gcdReady || reloadAbility.GCD == false)
            {
                if (reloadAbility.Use(pc.player))
                {
                    //Debug.Log ("Reloading, bullet amount is: " + pc.player.bullets.Value);
                }
                else
                {
                    //failure state
                }
            }
            else
            {
                //failure state
            }

        UpdateUI();
        
    }

    public void UseFirst ()
    {
       
            if (gcdReady || firstAbility.GCD == false)
            {
                if (firstAbility.Use(pc))
                {
                    //Debug.Log ("Using first ability charge is " + pc.player.charge.Value);
                }
                else
                {
                    //failure state
                }
            }
            else
            {
                //failure state;
            }

        UpdateUI();

        
    }

    public void UseSecond()
    {
        
            if (gcdReady || secondAbility.GCD == false)
            {
                if (secondAbility.Use(pc))
                {
                    //Debug.Log("Using second ability charge is " + pc.player.charge.Value);
                }
                else
                {
                    //failure state
                }
            }
            else
            {
                //failure state;
            }

        UpdateUI();

       
    }

    public void UseThird()
    {
       
            if (gcdReady || thirdAbility.GCD == false)
            {
                if (thirdAbility.Use(pc))
                {
                    //Debug.Log("Using third ability charge is " + pc.player.charge.Value);
                }
                else
                {
                    //failure state
                }
            }
            else
            {
                //failure state;
            }

        UpdateUI();
    }

    public void UseFourth()
    {
       
            if (gcdReady || fourthAbility.GCD == false)
            {
                if (fourthAbility.Use(pc))
                {
                    //Debug.Log("Using fourth ability charge is " + pc.player.charge.Value);
                }
                else
                {
                    //failure state
                }
            }
            else
            {
                //failure state;
            }

        UpdateUI();
    }

    public void UseFifth()
    {
       
            if (gcdReady || fifthAbility.GCD == false)
            {
                if (fifthAbility.Use(pc))
                {
                    //Debug.Log("Using fifth ability charge is " + pc.player.charge.Value);
                }
                else
                {
                    //failure state
                }
            }
            else
            {
                //failure state;
            }

        UpdateUI();
    }

    #endregion
    
}
    

