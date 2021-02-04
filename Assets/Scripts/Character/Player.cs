using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Entity
{
    public Charge charge;
    public Bullets bullets;


    public Player ()
    {
        name = "Scarlet Maple";
        //faction = Faction.factions[0];
        health = new Health();
        charge = new Charge();
        bullets = new Bullets();

    }

    public Player(string myName)
    {
        name = myName;
        //faction = Faction.factions[0];
        health = new Health();
        charge = new Charge();
        bullets = new Bullets();
    }

    public Player (string myName, float myHealth)
    {
        name = myName;
        //faction = Faction.factions[0];
        health = new Health(myHealth);
        charge = new Charge();
        bullets = new Bullets();
    }
}
