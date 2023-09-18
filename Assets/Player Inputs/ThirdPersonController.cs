using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;


//This script controls looking around
public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera Camera;
    [SerializeField] private float Sensitivity = 5.0f;

    private PlayerMovementManager movementController;

    //Cinemachine Variables
    public GameObject CinemachineCameraTarget;

    private float __CamYaw;
    private float __CamPitch;

    private const float __min_Input = 0.01f;
    public float TopClamp = 70.0f; //Max go up
    public float BottomClamp = -30.0f; //Max go down
    public float CamAngleOverride = 0.0f;
    public bool LockCamPosition = false;

    //Game Components
    private CharacterController __controller;
    private PlayerInput __playInput;
    private PlayerMovementManager __inputs;
    private GameObject __mainCam;

    //Player Variables
    private float playerVelocity;
    public float vertVelocity;
    public float horzVelocity;
    public float speed = 10f;

    //Player Camera and Rotation
    [SerializeField] public float turnSpeed = 10f;
    [SerializeField] public float smoothTime = 0.05f;
    private float __targetRotate;
    private float __angle;
    private Vector3 __direction;
    private float _curr_Velocity;
    private bool rotateOnMove = true;


    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (__mainCam == null)
        {
            __mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        __CamYaw = CinemachineCameraTarget.transform.rotation.eulerAngles.y;

        __controller = GetComponent<CharacterController>();
        __inputs = GetComponent<PlayerMovementManager>();
        __playInput = GetComponent<PlayerInput>();

    }

    // Update is called once per frame
    private void LateUpdate()
    {
        CamRotation();
    }


    //Functions
    private bool isDeviceMouse()
    {
        if (__playInput.currentControlScheme == "KeyboardMouse")
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void getMove(Vector2 input)
    {
        //Takes in the vector 2 input x + y
        Vector3 moveDir = Vector3.zero;
        moveDir.x = input.x;
        moveDir.z = input.y;
        
        if (input != Vector2.zero)
        {
            //Gets a target Rotation based on x and z. Essentially uses Tan in order to find the radians and then converts to a degree and adds it to the main cam transform. 
            __targetRotate = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg + __mainCam.transform.eulerAngles.y;

            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, __targetRotate, ref _curr_Velocity,
                smoothTime);

            // rotate to face input direction relative to camera position
            if (rotateOnMove)
            {
                transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            }

            //Change Character Direction
            Vector3 inputDirection = Quaternion.Euler(0.0f, __targetRotate, 0.0f) * Vector3.forward;

            __controller.Move(inputDirection.normalized * speed * Time.deltaTime                              /*transform.TransformDirection(moveDir) * speed * Time.deltaTime*/);
        }

    }

    private void CamRotation()
    {
        if (__inputs.look.sqrMagnitude >= __min_Input && !LockCamPosition)
        {
             float camMulti = isDeviceMouse() ? 1.0f : Time.deltaTime;

            __CamYaw += __inputs.look.x * camMulti * Sensitivity;
            __CamPitch -= __inputs.look.y * camMulti * Sensitivity;
        
        }

        __CamYaw = clampAngle(__CamYaw, float.MinValue, float.MaxValue);
        __CamPitch = clampAngle(__CamPitch, BottomClamp, TopClamp);

        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(__CamPitch + CamAngleOverride, __CamYaw, 0.0f);
    }

    private static float clampAngle(float Angle, float Min, float Max)
    {
        if (Angle < -360f) Angle += 360f;
        if (Angle > 360f) Angle -= 360f;
        return Mathf.Clamp(Angle, Min, Max);
    }


    public void setSensitivity(float newSensitivity)
    {
        Sensitivity = newSensitivity;
    }

}

