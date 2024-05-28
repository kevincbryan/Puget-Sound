using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Faction", menuName = "Factions")]
[System.Serializable]
public class Faction : ScriptableObject
{
    public static List<Faction> factions = new List<Faction>();
    //protected string name;
    public int startingRep = 0;
    [SerializeField] protected List<float> relations = new List<float>();
    [SerializeField] protected int position;
    protected bool runOnce = false;

    #region accessors
    public string Name
    {
        get
        {
            return name;
        }
    }

    public static List<Faction> Factions
    {
        get
        {
            return factions;
        }
    }

    public List<float> Relations
    {
        get
        {
            return relations;
        }
    }

    public int Identity
    {
        get
        {
            return position;
        }
    }
    #endregion

    #region constructors

    private void OnEnable() //Jury-riged constructor
    {
        if (!runOnce)
        {
            runOnce = true;
            factions.Add(this);
            position = factions.Count -1;

            for (int i = 0; i < factions.Count; i++) //Make relation values for all previously created factions
            {
                relations.Add(startingRep);
            }

            if (position != 0) //if not the first entry, add relations to all existing factions
            {
                for (int i = 0; i < factions.Count - 1; i++)
                {
                    factions[i].AddRelation(startingRep);
                }
            }

            relations[position] = 100; //Set own relations to perfect


        }
    }



/*
    public Faction ()
    {
        name = "Generic";
        factions.Add(this);
        position = factions.Count -1;
        //relations.Add(position);

        for (int i = 0; i < factions.Count; i++ ) //Make relation values for all previously created factions
        {
            relations.Add(0);
        }

        
        if (position != 0) //if not the first entry, add relations to all existing factions
        {
            for (int i = 0; i < factions.Count - 1; i++)
            {
                factions[i].AddRelation(0);
            }
        }

        relations[position] = 100; //Set own relations to perfect

    }

    public Faction(string myName)
    {
        name = myName;
        factions.Add(this);
        position = factions.Count - 1;
        //relations.Add(position);

        for (int i = 0; i < factions.Count; i++) //Make relation values for all previously created factions
        {
            relations.Add(0);
        }


        if (position != 0) //if not the first entry, add relations to all existing factions
        {
            for (int i = 0; i < factions.Count - 1; i++)
            {
                factions[i].AddRelation(0);
            }
        }

        relations[position] = 100; //Set own relations to perfect

    }

    public Faction (string myName, int affection) //Sets the relations for all factions besides self
    {

        if (affection > 100) affection = 100;
        if (affection < -100) affection = -100;

        name = myName;
        factions.Add(this);
        position = factions.Count - 1;
        //relations.Add(position);

        for (int i = 0; i < factions.Count; i++) //Make relation values for all previously created factions
        {
            relations.Add(affection);
        }

        if (position != 0) //if not the first entry, add relations to all existing factions
        {
            for (int i = 0; i < factions.Count - 1; i++)
            {
                factions[i].AddRelation(affection);
            }
        }

        relations[position] = 100;//Set own relations to perfect
    }
*/
    #endregion


    public void AddRelation (float reputation)
    {
        //Debug.Log ("Add relation has been called");
        if (reputation > 100) reputation = 100;
        if (reputation < -100) reputation = -100;
        relations.Add(reputation);
    }

    public bool Hate (int index, float hate)
    {
        if (index +1 <= relations.Count)
        {
            if (index != position)
            {
                float tempRep = relations[index];
                tempRep -= hate;

                if (tempRep > 100) tempRep = 100;
                if (tempRep < -100) tempRep = -100;

                relations[index] = tempRep;
                //Debug.Log ("Faction " + index + "Is now at " + relations[index] + " rep");
            }
            return (true);
        }
        return (false);
    }

    public bool Love(int index, float love)
    {
        if (index + 1 <= relations.Count)
        {
            if (index != position)
            {
                float tempRep = relations[index];
                tempRep += love;

                if (tempRep > 100) tempRep = 100;
                if (tempRep < -100) tempRep = -100;

                relations[index] = tempRep;
            }
            return (true);
        }
        return (false);
    }


    public bool SetRep(int index, float rep)
    {
        if (index + 1 <= relations.Count)
        {
            if (index != position)
            {
                

                if (rep > 100) rep = 100;
                if (rep < -100) rep = -100;

                relations[index] = rep;
            }
            return (true);
        }
        return (false);
    }
}
