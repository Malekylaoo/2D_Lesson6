using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerAnimations))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private int _moneyCount;

    private PlayerInput _playerInput;
    private Vector2 _moveDirection;
    private SpriteRenderer _spriteRenderer;
    private PlayerAnimations _animation;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _animation = GetComponent<PlayerAnimations>();

        _playerInput.Player.Attack.performed += ctx => OnAttack();
        _playerInput.Player.Jump.performed += ctx => OnJump();
    }

    private void FixedUpdate()
    {
        _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
        Move(_moveDirection);
        Flip(_moveDirection);
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Move(Vector2 direction)
    {
        _animation.Walk(direction);
        _rigidBody.velocity = new Vector2(direction.x * _speed, _rigidBody.velocity.y);
    }

    private void OnJump()
    {
        if (_groundChecker.isGrounded)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.y, _jumpForce);
            _animation.Jump();
        }
    }

    private void Flip(Vector2 direction)
    {
        if (direction.x < 0)
            _spriteRenderer.flipX = true;
        else if(direction.x > 0)
            _spriteRenderer.flipX = false;
    }

    private void OnAttack()
    {
        _animation.Attack();
    }

    public void TakeMoney()
    {
        _moneyCount++;
    }

}
