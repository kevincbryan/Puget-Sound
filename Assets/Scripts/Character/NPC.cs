using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    private SimpleFollow mFollow;
    // Start is called before the first frame update
    void Start()
    {
        entity = new Entity (cName, hp);
        entity.faction = faction;
        mFollow = gameObject.GetComponent<SimpleFollow>();
    }

    private void OnEnable() 
    {
        //Health.Died += Delete;
    }

    private void OnDisable() 
    {
        //Health.Died -= Delete;
    }



    // Update is called once per frame
    void Update()
    {
        if (entity.health.Value <= 0)
        {
            if (mFollow) mFollow.canMove = false;
            Delete();
        }
    }

    public void Delete ()
    {
        //Debug.Log (" NPC should delete");
        //Destroy (gameObject, 1f);
        gameObject.SetActive(false);
    }
}
