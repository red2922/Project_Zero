using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementManager : MonoBehaviour
{
    //Variables
    private PlayerControls playerMovements;
    private PlayerControls.MovementActions basicMovements;

    private PlayerMovements move;
    private PlayerMotor motor;
    

    //Essentially Main/What is going to be player in game
    void Awake()
    {
        playerMovements = new PlayerControls();
        basicMovements = playerMovements.Movement;
        motor = GetComponent<PlayerMotor>();

        
    }

    // Update is called once per frame
    void Update()
    {
        motor.getMove(basicMovements.basicMovement.ReadValue<Vector2>());
    }

    //Functions

    //Essentially being able to disable vs enable movement
    private void OnEnable()
    {
        basicMovements.Enable();
    }

    private void OnDisable()
    {
        basicMovements.Disable();
    }





}
