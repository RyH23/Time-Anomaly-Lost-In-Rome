using UnityEngine;

public class S_PlayerController : MonoBehaviour
{
    #region Components
    private CharacterController _controller;
    private ArenaManager _arenaManager;
    #endregion

    #region Movement Settings
    [Header("Movement")]
    [SerializeField] private float _baseSpeed = 5f;
    [SerializeField] private float _sprintSpeed = 10f;
    [SerializeField] private float _sprintTransitionSpeed = 5f;

    #region Dash
    [Header("Dash")]
    [SerializeField] private float _dashSpeed = 20;
    [SerializeField] private float _dashDuration = 0.15f;
    [SerializeField] private float _dashCooldown = 1;

    private bool _isDashing;
    private float _dashTimeRemaining;
    private float _lastDashTime;
    private Vector3 _dashDirection;
    #endregion

    [Header("Jump & Gravity")]
    [SerializeField] private float _jumpHeight = 2f;
    [SerializeField] private float _gravity = 9.8f;
    #endregion

    #region State
    private float _currentSpeed;
    private float _verticalVelocity;

    private Vector3 _airVelocity;
    private Vector3 _jumpDirection;
    #endregion

    #region Input
    private float _moveInput;
    private float _turnInput;
    #endregion

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        ReadInput();
        HandleMovement();
    }

    // =========================
    // INPUT
    // =========================
    private void ReadInput()
    {
        _moveInput = Input.GetAxis("Vertical");
        _turnInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Dash();
        }
    }

    // =========================
    // MOVEMENT
    // =========================
    private void HandleMovement()
    {
        Vector3 horizontal = CalculateHorizontalMovement();
        float vertical = CalculateVerticalMovement();

        Vector3 movement = horizontal + Vector3.up * vertical;
        _controller.Move(movement * Time.deltaTime);
    }

    // -------------------------
    // Horizontal Movement
    // -------------------------
    private Vector3 CalculateHorizontalMovement()
    {
        if (_isDashing)
        {
            _dashTimeRemaining -= Time.deltaTime;

            if (_dashTimeRemaining < 0 )
            {
                _isDashing = false;
            }

            return _dashDirection * _dashSpeed;
        }

        Vector3 inputDirection = transform.right * _turnInput + transform.forward * _moveInput;

        inputDirection = Vector3.ClampMagnitude(inputDirection, 1f);

        UpdateSpeed();

        Vector3 desiredVelocity = inputDirection * _currentSpeed;

        if (_controller.isGrounded)
        {
            CacheJumpDirection(inputDirection);
            _airVelocity = desiredVelocity;
        }
        else
        {
            desiredVelocity = _airVelocity;
        }

        return desiredVelocity;
    }

    private void CacheJumpDirection(Vector3 inputDirection)
    {
        if (inputDirection.sqrMagnitude > 0f)
        {
            _jumpDirection = inputDirection.normalized;
        }
    }

    private void UpdateSpeed()
    {
        float targetSpeed = Input.GetKey(KeyCode.LeftShift)
            ? _sprintSpeed
            : _baseSpeed;

        _currentSpeed = Mathf.Lerp(_currentSpeed, targetSpeed, _sprintTransitionSpeed * Time.deltaTime);
    }

    private void Dash()
    {
        if (_isDashing) return;
        if (Time.time < _lastDashTime + _dashCooldown) return;

        Vector3 inputDirection = transform.right * _turnInput + transform.forward * _moveInput;

        if (inputDirection.sqrMagnitude == 0)
        {
            inputDirection = transform.forward;
        }

        _dashDirection = inputDirection.normalized;
        _isDashing = true;
        _dashTimeRemaining = _dashDuration;
        _lastDashTime = Time.time;
    }

    // -------------------------
    // Vertical Movement
    // -------------------------
    private float CalculateVerticalMovement()
    {
        if (_controller.isGrounded)
        {
            _verticalVelocity = -1f;
            Jump();
        }
        else
        {
            _verticalVelocity -= _gravity * Time.deltaTime;
        }

        return _verticalVelocity;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _verticalVelocity = Mathf.Sqrt(_jumpHeight * 2f * _gravity);
        }
    }
}

