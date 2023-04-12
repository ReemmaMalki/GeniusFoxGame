using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovments :MonoBehaviour
{
    
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;


    // Update is called once per frame
    void Update()
    {
        //control the player movement
       float horizontal = Input.GetAxisRaw("Horizontal"); //moving left and right
       float vertical = Input.GetAxisRaw("Vertical"); //moving forward and backward
       Vector3 direction = new Vector3(horizontal,0f,vertical).normalized;

        if (direction.magnitude >= 0.1f){

            float targetAngle = Mathf.Atan2(direction.x,direction.z)* Mathf.Rad2Deg + cam.eulerAngles.y  ; 
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,angle,0f);
            
            Vector3 moveDir = Quaternion.Euler(0f,targetAngle,0f) * Vector3.forward;
            controller.Move(moveDir.normalized*speed*Time.deltaTime);
             
        }
    }
}