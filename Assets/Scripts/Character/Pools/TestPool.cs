using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPool : MonoBehaviour
{

    private Charge energy;
    public Player player;
    public Revolver mRevolver;
    public Defense mDefense;
    public ClawFrenzy mClawFrenzy;
    public HookKick mHookKick;
    public BiteHeal mBiteHeal;
    public DeathLaser mDeathLaser;
    
    // Start is called before the first frame update
    void Start()
    {

        /*
        player = new Player();
        Debug.Log("I have " + player.charge.Value + " Charge.");
        Debug.Log("I have " + player.bullets.Value + " Bullets left");
        Debug.Log(mRevolver.Use(player));
        Debug.Log("I have " + player.bullets.Value + " Bullets left");
        Debug.Log("I have " + player.charge.Value + " Charge.");
        Debug.Log(mRevolver.Use(player));
        Debug.Log(mRevolver.Use(player));
        Debug.Log(mRevolver.Use(player));
        Debug.Log(mRevolver.Use(player));
        Debug.Log(mRevolver.Use(player));
        Debug.Log(mRevolver.Use(player));
        Debug.Log("I have " + player.bullets.Value + " Bullets left");
        Debug.Log("I have " + player.charge.Value + " Charge.");
        Debug.Log(mDeathLaser.Ready(player));
        player.health.Damage(5f);
        Debug.Log("Player has " + player.health.Value + " Life");
        Debug.Log(mDeathLaser.Use(player));
        Debug.Log("Player has " + player.health.Value + " Life");
        Debug.Log("I have " + player.charge.Value + " Charge.");
        Debug.Log(mDeathLaser.Use(player));
        Debug.Log(mDeathLaser.Use(player));
        Debug.Log(mDeathLaser.Use(player));
        Debug.Log(mDeathLaser.Use(player));
        Debug.Log("I have " + player.charge.Value + " Charge.");

    */


        /*
        energy = new Charge();
      
        PlayerHealth hitPoints = new PlayerHealth(13f);
        Debug.Log("Current Health is :" + hitPoints.Value);
        hitPoints.Damage(100f);

        Bullets mBullets = new Bullets(7);
        mBullets.Spend (1);
        Debug.Log("Current bullets are " + mBullets.Value);

        mBullets.Reload();

        Debug.Log("Current bullets are " + mBullets.Value);

        mBullets.Fire();

        Debug.Log("Current bullets are " + mBullets.Value);

        Debug.Log("Can you fire 50 bullets? " + mBullets.Fire(50f));

        
        Faction peta = new Faction("Peta");
        Faction antifa = new Faction ("Antifa");
        Faction tigers = new Faction ("Tigers");
        Faction sPD = new Faction ("SPD");
        
        
        Debug.Log(sPD.Relations[peta.Identity]);
        sPD.Hate(peta.Identity, 50);
        Debug.Log(sPD.Relations[peta.Identity]);
        sPD.SetRep(peta.Identity, -250);
        Debug.Log(sPD.Relations[peta.Identity]);
        sPD.Love(peta.Identity, 50);
        Debug.Log(sPD.Relations[peta.Identity]);
        //Faction bob = new Faction();
        //Debug.Log(bob.Relations.Count);
        //Faction steve = new Faction();


        
        //bob.AddRelation(steve.Identity, 0);
        //Debug.Log(bob.Relations.Count);
        //Debug.Log(bob.Relations[steve.Identity]);

        */





    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
