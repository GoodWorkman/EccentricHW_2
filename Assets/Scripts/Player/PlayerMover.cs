using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(CharacterController))]

public class PlayerMover : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSensetivity = 50f;
    [SerializeField] private float _jumpHeight = 2f;
    
    [Header("Gravity Settings")]
    [SerializeField] private float _gravity = -40f;
    [SerializeField] private float _continuosForce = -4f;

    [Header("Ground Check Settings")]
    [SerializeField] private float _checkRadious = 0.4f;
    [SerializeField] private LayerMask _groudLayer;
    [SerializeField] private Transform _groudpoint;
    
    private InputReader _input;
    private CharacterController _controller;

    private Vector3 _velocity;
    private bool _isGrounded;
    private bool _isMoving;

    private float _speedMultiplier = 1.5f;
    private float _currentSpeed;

    public bool IsGrounded => _isGrounded;
    public bool IsMoving => _isMoving;
   
    private void OnValidate()
    {
        _input ??= GetComponent<InputReader>();
        _controller ??= GetComponent<CharacterController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
       CheckGround();
       Move();
       TryJump();
       ApplyGravity();
    }

    private void LateUpdate()
    {
        float rotationSpeed = _input.MouseX * _rotationSensetivity * Time.fixedDeltaTime;
        
        transform.Rotate(Vector3.up * rotationSpeed);
    }

    private void CheckGround()
    {
        _isGrounded = Physics.CheckSphere(_groudpoint.position, _checkRadious, _groudLayer);
    }

    private void TryJump()
    {
        if (_isGrounded && _input.IsJump)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }
    }
    
    private void ApplyGravity()
    {
        if (_isGrounded == false)
        {
            _velocity.y += _gravity * Time.deltaTime;
        }
        else if (_velocity.y < 0)
        {
            _velocity.y = _continuosForce;
        }
        
        _controller.Move(_velocity * Time.deltaTime);
    }

    private void Move()
    {
        Vector3 direction = (transform.forward * _input.Vertical + transform.right * _input.Horizontal).normalized;

        _isMoving = direction.magnitude > 0.2f;
        
        _currentSpeed = _input.IsAccelerate ? _speed * _speedMultiplier : _speed;
        
        _controller.Move(direction * (_currentSpeed * Time.deltaTime));
    }
}
