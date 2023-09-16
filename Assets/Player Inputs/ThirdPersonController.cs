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

    private void CamRotation()
    {
        if (__inputs.look.sqrMagnitude >= __min_Input && !LockCamPosition)
        {
             float camMulti = isDeviceMouse() ? 1.0f : Time.deltaTime;

            __CamYaw += __inputs.look.x * camMulti * Sensitivity;
            __CamPitch -= __inputs.look.y * camMulti * Sensitivity;
        
        }

        __CamYaw = ClampAngle(__CamYaw, float.MinValue, float.MaxValue);
        __CamPitch = ClampAngle(__CamPitch, BottomClamp, TopClamp);

        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(__CamPitch + CamAngleOverride, __CamYaw, 0.0f);

    }

    private static float ClampAngle(float Angle, float Min, float Max)
    {
        if (Angle < -360f) Angle += 360f;
        if (Angle > 360f) Angle -= 360f;
        return Mathf.Clamp(Angle, Min, Max);
    }


   







}

