using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
   protected string name;
   public Faction faction;
   public Health health;

#region accessors
    public string Name
    {
        get
        {
            return name;
        }
    }

#endregion

#region constructors
    public Entity ()
    {
        name = "Johnson";
        health = new Health();
    }
    
    
    
    public Entity (string myName)
    {
        name = myName;
        //faction = Faction.factions[0];
        health = new Health();
    }

    public Entity (string myName, float myHealth)
    {
        name = myName;
        //if (Faction.factions.Count > 0)faction = Faction.factions[0];
        health = new Health(myHealth);
        
    }

    public Entity (string myName, float myHealth, Faction myFaction)
    {
        name = myName;
        faction = myFaction;
        health = new Health(myHealth);

    }

    public Entity (string myName, float myHealth, int factionIdentity)
    {
        name = myName;
        //if (Faction.factions.Count > factionIdentity)faction = Faction.factions[factionIdentity];
        health = new Health(myHealth);
    }
#endregion

}
