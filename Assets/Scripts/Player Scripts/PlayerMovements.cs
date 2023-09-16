using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    //Variables
    private CharacterController Player;
    private Vector3 playerVelocity;
    public float speed = 8f;
 

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Functions
    public void GetMove(Vector2 input) // Get Player inputs (Controller or keyboard)
    {
        Vector3 moveDirection = Vector3.zero;
    }

}
