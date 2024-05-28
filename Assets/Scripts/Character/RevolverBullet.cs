using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverBullet : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 1000f;
    public float damage = 5f;
    public float reputationDamage = 50f;
    public Faction sFaction;
    public float timeToDestroy = 5f;
    public PC pc;
    public Revolver sourceAbility;
    private Vector3 localForward;


    // Start is called before the first frame update
    void Start()
    {
        Destroy (gameObject, timeToDestroy);
        rb = gameObject.GetComponent<Rigidbody>();
        localForward = transform.rotation * Vector3.forward;
        //rb.AddForce(localForward, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() 
    {
        Vector3 localForward = transform.rotation * Vector3.forward;
        rb.AddForce(localForward * Time.fixedDeltaTime * speed);
    }


    private void OnCollisionEnter(Collision other) 
    {
        //Debug.Log(other + " hit");
        NPC enemy = other.gameObject.GetComponent<NPC>();

        if (enemy)
        {
            if (sourceAbility)
            {
                sourceAbility.Strike(enemy.entity, other, pc);
            }
        }
    }
}
