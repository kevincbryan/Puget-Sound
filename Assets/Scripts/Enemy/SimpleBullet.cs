using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour
{

    private Rigidbody rb;
    public float speed = 1000f;
    public float damage = 5f;
    public float reputationDamage = 50f;
    public Faction sFaction;
    public float timeToDestroy = 5f;
    public Entity npc;
    //public Revolver sourceAbility;
    private Vector3 localForward;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
        rb = gameObject.GetComponent<Rigidbody>();
        localForward = transform.rotation * Vector3.forward;
        //rb.AddForce(localForward, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        Vector3 localForward = transform.rotation * Vector3.forward;
        rb.AddForce(localForward * Time.fixedDeltaTime * speed);
    }


    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other + " hit");
        NPC enemy = other.gameObject.GetComponent<NPC>();
        PC player = other.gameObject.GetComponent<PC>();

        if (enemy)
        {
            if (npc.health.Value > 0)
            {
                enemy.entity.health.Damage(damage, npc);
            }
        }

        if (player)
        {
            if (npc.health.Value > 0)
            {
                player.player.health.Damage(damage, npc);
            }
        }

        //Destroy(gameObject, .05f);
    }
}
