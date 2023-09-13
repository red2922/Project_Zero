using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;


//This script controls looking around
public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera Camera;
    [SerializeField] private float Sensitivity = 1.0f;

    private PlayerMovementManager movementController;




    //Cinemachine Variables
    public GameObject CinemachineCameraTarget;

    public float TopClamp = 70.0f; //Max go up
    public float BottomClamp = -30.0f; //Max go down



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        








    }


    private void CamRotation()
    {

















    }












}

