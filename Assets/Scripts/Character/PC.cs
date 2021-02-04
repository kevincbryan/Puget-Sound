using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{

    public Player player;
    public string pName = "Scarlet Maple";
    public float hp = 100f;

    // Start is called before the first frame update
    void Start()
    {
        player = new Player (pName, hp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
