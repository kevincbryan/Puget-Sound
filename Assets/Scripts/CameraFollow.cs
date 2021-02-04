using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform cameraFollow;
    public Transform player;
    public Rigidbody pRB;
    public Camera mCam;
    public float cameraMoveSpeed = 10f;
    public float cameraTurnSpeed = 90f;
    public float directTurnSpeed = 360f;
    private Vector3 targetRotation;
    private Quaternion targetRot;
    private Vector3 currentRotation;
    private Vector3 pTargetRotation;
    private Quaternion pTargetRot;

    private Vector3 mouseInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetButtonDown ("Fire2"))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetButtonUp ("Fire2"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        
       

        if (!Input.GetButton("Fire2"))  //If not pressing right click move camera based on the player
        {
            targetRotation = cameraFollow.rotation.eulerAngles;  //Get player rotation
            currentRotation = transform.rotation.eulerAngles; //Get our rotation


            targetRotation.x = currentRotation.x; //use player X, and our Y and Z as target
            targetRotation.z = currentRotation.z;
            targetRot = Quaternion.Euler(targetRotation);
            transform.position = Vector3.Lerp(transform.position, cameraFollow.position, cameraMoveSpeed * Time.deltaTime); //move camera to new position


            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * cameraTurnSpeed); //Lerp x rotation to player rotation
        }
        else //if pressing right click, use mouse movement to drag the camera
        {
            currentRotation = transform.rotation.eulerAngles;
            targetRotation = currentRotation;
            mouseInput.x = -1 * Input.GetAxisRaw("Mouse Y"); //Get Mouse Drag r/l and u/d
            mouseInput.y = 1 * Input.GetAxisRaw("Mouse X");
            

            targetRotation.x = targetRotation.x + mouseInput.x; //swap out current position with r/l and u/d values
            targetRotation.y = targetRotation.y +  mouseInput.y;
            targetRot = Quaternion.Euler(targetRotation);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * directTurnSpeed); //lerp rotation to new rotation


           pTargetRotation = player.transform.rotation.eulerAngles; //Get player rotation
           currentRotation = transform.rotation.eulerAngles; //Get our rotation;

           pTargetRotation.y = currentRotation.y; //sets player target y to our y;
           pTargetRot = Quaternion.Euler(pTargetRotation);
           player.rotation = Quaternion.Lerp(player.rotation, pTargetRot, Time.deltaTime * directTurnSpeed);



            



            transform.position = Vector3.Lerp(transform.position, cameraFollow.position, cameraMoveSpeed * Time.deltaTime); //move camera to new position
        }



       
    }
}
