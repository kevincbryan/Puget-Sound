using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFactions : MonoBehaviour
{

    public Faction player;
    public Faction bremerton;
    // Start is called before the first frame update
    void Start()
    {
        

        if (bremerton)
        {
            bremerton.SetRep(player.Identity, 0);
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
