using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private const string _IsMoving = "isMoving";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Walk(bool isMoving)
    {
        _animator.SetBool(_IsMoving, isMoving);
    }

}
