using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[ExecuteInEditMode]
public class CameraControlls : MonoBehaviour 
{
    public Transform PlayerTransform;

    public Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;
    public bool LookAtPlayer = false;
    public bool RotateAroundPlayer = true;
    public bool RotateButton = true;
    public float RotationsSpeed = 5.0f;
    public float RotationsSpeedCont = 50.0f;
    //Zoom Stuff
    public float PlayerCameraDistance { get; set; }
    Camera playerCamera;
    public float zoomSpeed = 35f;

    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;

        PlayerCameraDistance = 12f;
        playerCamera = GetComponent<Camera>();
    }
    private bool IsRotateActive
    {
        get
        {
            if (!RotateAroundPlayer)
                return false;

            if (!RotateButton)
                return true;

            if (RotateButton && Input.GetMouseButton(1))
                return true;

            return false;
        }
    }

    void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0 && !EventSystem.current.IsPointerOverGameObject())
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            playerCamera.fieldOfView -= scroll * zoomSpeed;
            playerCamera.fieldOfView = Mathf.Clamp(playerCamera.fieldOfView, 0, 180);
        }

        transform.position = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y + PlayerCameraDistance, PlayerTransform.position.z - PlayerCameraDistance);
    }

    void LateUpdate()
    {
        if (IsRotateActive)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationsSpeed, Vector3.up);
            _cameraOffset = camTurnAngle * _cameraOffset;
        }

        if (!IsRotateActive)   //NOTE: Cheatway to make controller rotation work, by just allowing it when the mouse isnt being pressed
        {
        Quaternion camTurnAngle2 = Quaternion.AngleAxis(Input.GetAxis("Controler X") * RotationsSpeedCont, Vector3.up);
        _cameraOffset = camTurnAngle2 * _cameraOffset;
        }


    //Camera Zoom
        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if (LookAtPlayer || RotateAroundPlayer)
            transform.LookAt(PlayerTransform);
    }
}
