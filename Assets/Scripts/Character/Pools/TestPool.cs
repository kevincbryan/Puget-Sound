using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPool : MonoBehaviour
{

    private Charge energy;
    
    // Start is called before the first frame update
    void Start()
    {
        energy = new Charge();
      
        Health hitPoints = new Health(13f);
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





    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
