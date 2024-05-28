using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAttack : MonoBehaviour
{
    public float attackDelay = 3f;
    public GameObject enemyBullet;
    //public SimpleBullet mBullet;
    private Faction mFaction;
    private NPC mNPC;
    public float damage = 1f;
    public float repDamage = 1f;
    private float timer = 0f;
    private float range = 100f;

    private Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mNPC = GetComponent<NPC>();
        //if (mNPC) mFaction = mNPC.entity.faction;

        //if (enemyBullet) mBullet = enemyBullet.GetComponent<SimpleBullet>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= attackDelay)
        {
            
            if (player)
            {

                //Debug.Log("Time is reached, should fire now");
                //Debug.Log (Vector3.Distance(player.position, transform.position));
                if (Vector3.Distance(player.position, transform.position) <= range)
                {
                    //Debug.Log ("Player in range should fire");
                    FireBullet();
                    timer = 0;
                }
            }
        }

    }

    void FireBullet()
    {

        Debug.Log("Bullet is fired");
        Vector3 direction = player.position - transform.position;
        if (enemyBullet)
        {
            GameObject mBullet = Instantiate(enemyBullet, (transform.position + (transform.forward * 1f)), Quaternion.LookRotation(direction));
            if (enemyBullet)
            {
                SimpleBullet bulletData = mBullet.GetComponent<SimpleBullet>();
                //enemyBullet.sFaction = pc.entity.faction;
                bulletData.npc = mNPC.entity;
                bulletData.damage = damage;
                //bulletData.sFaction = mNPC.entity.faction;
                //enemyBullet.sourceAbility = this;
            }
        }
    }
}
