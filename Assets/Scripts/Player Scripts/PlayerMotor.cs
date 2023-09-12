using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController player;
    private Vector3 playerVelocity;
    public float speed = 10f;






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






}
