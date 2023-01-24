using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;

    private Animator _animator;
    private const string _attack = "Attack";
    private const string _walk = "MoveX";
    private const string _grounded = "isGrounded";
    private const string _jump = "Jump";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Jump()
    {
        _animator.Play(_jump);
    }

    public void Attack()
    {
        _animator.Play(_attack);
    }

    public void Walk(Vector2 direction)
    {
        _animator.SetFloat(_walk, Mathf.Abs(direction.x));
    }

    public void ChangeIsGrounded(bool isGrounded)
    {
        _animator.SetBool(_grounded, isGrounded);
    }
}
