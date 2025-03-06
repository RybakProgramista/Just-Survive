using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Player characrer controller
    private CharacterController _playerCharacterController;
    //Player basics inputs
    private PlayerInput _playerInput;
    //Move action
    private InputAction _moveAction;
    //Jump action
    private InputAction _jumpAction;
    //Player movement represented as Vector2
    private Vector2 _movement;
    //Player jump velocity
    private float _jumpVelocity;
    //Boolean representing if jump button is pressed
    private bool _jumpPressed;
    //Boolean representing if player is grounded
    private bool _isGrounded;

    //worlds gravity
    private float _gravitationDrag = 0.5f;

    //Players walk speed
    [SerializeField]
    private float _walkSpeed;
    public float WalkSpeed
    {
        get { return _walkSpeed; }
        set { _walkSpeed = value; }
    }

    //Players jump force
    [SerializeField]
    private float _jumpHeight;
    public float JumpHeight
    {
        get { return _jumpHeight; }
        set { _jumpHeight = value; }
    }

    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerCharacterController = GetComponent<CharacterController>();
        _moveAction = _playerInput.actions.FindAction("Move");
        _jumpAction = _playerInput.actions.FindAction("Jump");
    }

    void FixedUpdate()
    {
        JumpPlayer();
        MovePlayer();
    }
    /// <summary>
    /// Fuction that calculates player movement
    /// </summary>
    private void MovePlayer()
    {
        _movement = _moveAction.ReadValue<Vector2>();
        Vector3 localMovement = new Vector3(_movement.x, 0, _movement.y) * _walkSpeed;
        Vector3 globalMovement = transform.TransformDirection(localMovement);
        _playerCharacterController.Move(new Vector3(
            globalMovement.x * Time.deltaTime,
            _jumpVelocity * Time.deltaTime,
            globalMovement.z * Time.deltaTime
        ));
    }
    /// <summary>
    /// Function that checks if player can jump and do if so
    /// </summary>
    private void JumpPlayer()
    {
        _isGrounded = _playerCharacterController.isGrounded;
        Debug.Log(_isGrounded);
        if(_isGrounded && _jumpPressed)
        {
            _jumpPressed = false;
            _jumpVelocity = _jumpHeight;
        }
        _jumpVelocity -= _gravitationDrag;
    }
    /// <summary>
    /// Function executed on "jump" button click
    /// </summary>
    private void OnJump()
    {
        if (_playerCharacterController.velocity.y == 0)
        {
            _jumpPressed = true;
        }
    }
}
