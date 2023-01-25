using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;

    private const string _Attack = "Attack";
    private const string _Walk = "MoveX";
    private const string _Grounded = "isGrounded";
    private const string _Jump = "Jump";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Jump()
    {
        _animator.Play(_Jump);
    }

    public void Attack()
    {
        _animator.Play(_Attack);
    }

    public void Walk(Vector2 direction)
    {
        _animator.SetFloat(_Walk, Mathf.Abs(direction.x));
    }

    public void ChangeIsGrounded(bool isGrounded)
    {
        _animator.SetBool(_Grounded, isGrounded);
    }
}
