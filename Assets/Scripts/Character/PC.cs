using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : Character
{

    public Player player;
    //public string pName = "Scarlet Maple";
    //public float hp = 100f;
    //private Transform mTransform;

    // Start is called before the first frame update
    void Start()
    {
        player = new Player (cName, hp);
        entity = player;
        player.faction = faction;
        //mTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
