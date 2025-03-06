using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    //Player input system
    private PlayerInput _playerInput;
    //Player look action
    private InputAction _lookAction;
    //Camera transform
    private Transform _cameraTransform;

    //look vector
    private Vector2 _lookInputVector;
    //cameras rotation
    private float _xRotation;


    //Player camera sensitivity
    [SerializeField]
    private float _cameraSensitivity;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _lookAction = _playerInput.actions.FindAction("Look");

        _cameraTransform = Camera.main.transform;
        _xRotation = 0f;
    }

    private void FixedUpdate()
    {
        Rotation();
    }
    /// <summary>
    /// Functions that calculates the camera and player body rotation
    /// </summary>
    private void Rotation()
    {
        _lookInputVector = _lookAction.ReadValue<Vector2>();

        float mouseX = _lookInputVector.x * _cameraSensitivity * Time.deltaTime;
        float mouseY = _lookInputVector.y * _cameraSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        _cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
