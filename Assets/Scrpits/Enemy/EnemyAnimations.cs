using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private Animator _animator;
    private const string _isMoving = "isMoving";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Walk(bool isMoving)
    {
        _animator.SetBool(_isMoving, isMoving);
    }

}
