using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController player;
    private Vector3 playerVelocity;
    public float speed = 10f;
    public float turnSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Functions

    //Recieve inputs from Manager and appy them to character controller. 
    public void getMove(Vector2 input)
    {
        Vector3 moveDir = Vector3.zero;
        moveDir.x = input.x;
        moveDir.z = input.y;

        player.Move(transform.TransformDirection(moveDir) * speed * Time.deltaTime);

    }

    public void CharRotation(Vector2 input)
    {
        Vector3 rotateChar = Vector3.zero;
 

        if (((input.x == 1) && (input.y == 1)) | (input.x == 1))
        {
            rotateChar = new Vector3(0, turnSpeed * Time.deltaTime, 0);
        }

        else if (input.x == -1) 
        {
            rotateChar = new Vector3(0, -turnSpeed * Time.deltaTime, 0);
        }

        /*else if (input.y == 1)
        {
           rotateChar = new Vector3(0, 0, 0);
        }

        else if (input.y == -1)
        {
           rotateChar = new Vector3(0, -180, 0);
        }*/


        transform.Rotate(0.0f, 10.0f * Time.deltaTime, 0.0f, Space.Self);
        //transform.Rotate(rotateChar);
    }

}
