using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private bool _isGrounded;
    [SerializeField] private PlayerAnimations _playerAnimations;
    public bool isGrounded => _isGrounded;

    private void OnTriggerStay2D(Collider2D collision)
    {
        _isGrounded = true;
        _playerAnimations.ChangeIsGrounded(_isGrounded);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isGrounded = false;
        _playerAnimations.ChangeIsGrounded(_isGrounded);
    }
}
