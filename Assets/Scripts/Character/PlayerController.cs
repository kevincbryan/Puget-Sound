using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 10f;
    private float currentSpeed;
    public Rigidbody rb;
    public GameObject player;
    public bool movable = true;
    public bool isMoving = false;
    public float jumpStrength = 10f;
    public float jumpDuration = 1f;

    private Vector3 movement;
    private Vector3 tempMovement; //Might not need
    public float turnSpeed = 180f;
    private Vector3 yRotation;
    private Quaternion deltaRotation;
    //private float jumpAmount;
    private bool isJumping;
    //private Vector3 down;
    
    public Transform jumpChecker;
    private float jumpStartTime;
    private Vector3 jumpAltitude;
    private bool firstJumpEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.y = 0f;
        //down = transform.TransformDirection (Vector3.down);

        if (movable)
        {
            movement.x = Input.GetAxisRaw("Strafe"); //get Strafing and vertical input
            movement.z = Input.GetAxisRaw("Vertical");
            movement = movement.normalized;
            movement = player.transform.TransformDirection(movement);

            yRotation.y = Input.GetAxisRaw("Horizontal"); //Get turning input

            tempMovement = movement; //Stores movement for next update calculations
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
            movement.z = 0;
        }

        if (movement.x != 0 || movement.z != 0)
        {
            isMoving = true;
            
        }
        else
        {
            isMoving = false;
        }

        if (movable)
        {
            if (isJumping = Input.GetButtonDown("Jump"))
            {

                RaycastHit checker;
                //Physics.Raycast(jumpChecker.position, Vector3.down, 100f, 8);
                //Debug.Log ("Trying to Jump");
                if (Physics.Raycast(jumpChecker.position, Vector3.down, out checker,.7f))
                {
                    //Debug.Log("Is Jumping");
                    firstJumpEnabled = true;
                    jumpStartTime = Time.time;  //First active jump enables jump code
                }

                //Debug.Log (checker.collider);

            }
        }
    }

    private void FixedUpdate()
    {
        if (movable)
        {
            //rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            deltaRotation = Quaternion.Euler(yRotation * turnSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
            //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            if (Time.time < (jumpStartTime + jumpDuration) && firstJumpEnabled) //Only runs a jump as long as the duration, stopped if player hasn't hit jump yet
            {
                jumpAltitude.y = Mathf.Clamp(jumpStrength * Mathf.Sin(Mathf.PI * ((Time.time - jumpStartTime) / jumpDuration)), 0f, 100f);
                //Debug.Log(jumpAltitude.y);
                //rb.MovePosition (rb.position + jumpAltitude*Time.fixedDeltaTime);
                movement.y = jumpAltitude.y;
            }
            
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        }
    }
}
