using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RigidSlow : MonoBehaviour
{
    private Rigidbody rb;
    private NavMeshAgent mMesh;
    public float slowSpeed = 6f;
    public float slowDelay = 3f;
    public bool timer = false;
    private float internalTime;
    private bool slowDown = false;
    public float NavOffTime = 5f;


    // Start is called before the first frame update
    void Start() 
    {
        //Debug.Log ("Hello rigidSlow");
        rb = gameObject.GetComponent<Rigidbody>();
        mMesh = gameObject.GetComponent<NavMeshAgent>();
        //Debug.Log(rb);
    }

    public void NavOff ()
    {
        if (mMesh)
        {
            mMesh.enabled = false;
            Invoke ("NavOn", NavOffTime);
        }
    }

    public void NavOn ()
    {
        if (mMesh)
        {
            mMesh.enabled = true;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(transform.position, out hit, 10f, NavMesh.AllAreas))
            {
                mMesh.Warp(hit.position + new Vector3(0, 1f, 0));
            }
            else
            {
                mMesh.enabled = false;
                gameObject.SetActive(false);
            }
            
        }
    }


    private void Update() 
    {
        if (rb.angularVelocity.x > 0 || rb.angularVelocity.y > 0 || rb.angularVelocity.z > 0 || rb.velocity.x > 0 || rb.velocity.y > 0 || rb.velocity.z > 0) //if moving and not slowing, prepare to slow
        {

            if (!timer)
            {
                timer = true;
                internalTime = 0;
               // Debug.Log("Slow has been triggered");
            }
        
        }

        if (timer) //countdown to slow
        {
            internalTime += Time.deltaTime;
        }

        if (internalTime >= slowDelay && timer) //if countdown is reached start slow
        {
            slowDown = true;
           // Debug.Log ("Slow down has started");
            internalTime = 0;
        }


    }



    // Update is called once per frame
    private void FixedUpdate() 
    {
        //Debug.Log("rigid slow exists");
       

       if (rb.angularVelocity.x > 0 || rb.angularVelocity.y > 0 || rb.angularVelocity.z > 0 || rb.velocity.x > 0 || rb.velocity.y > 0 || rb.velocity.z > 0) //if moving
       {

           if (slowDown) //if told to slow down, start slowing down
           {
                rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, Vector3.zero, Time.deltaTime * slowSpeed);
                rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, Time.deltaTime * slowSpeed);
           }
            
       }
       else
       {
           if (slowDown) //if slowing down and stopped, reset
           {
               slowDown = false;
               timer = false;
           }
       }

       /*
        if (rb.angularVelocity.x > 0 || rb.angularVelocity.y > 0 || rb.angularVelocity.z > 0)
        {
            rb.angularVelocity = Vector3.Lerp (rb.angularVelocity, Vector3.zero, Time.deltaTime * slowSpeed);
            //rb.angularVelocity = Vector3.zero;
            Debug.Log("Slowing down spin");
        }


        if (rb.velocity.x > 0 || rb.velocity.y > 0 || rb.velocity.z > 0)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, Time.deltaTime * slowSpeed);
            //rb.velocity = Vector3.zero;
            Debug.Log("Slowing down speed");
        }

        */
    }
    

}
