using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimations))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _moveSpots;
    [SerializeField] private float _speed;
    [SerializeField] private float _waitTime;
    [SerializeField] private float _startWaitTime;
    [SerializeField] private float _distance;
    [SerializeField] private EnemyAnimations _ememyAnimations;

    private int _randomSpot;

    private void Start()
    {
        _randomSpot = Random.Range(0, _moveSpots.Length);
        _waitTime = _startWaitTime;
    }

    private void Update()
    {
        Move();
        CheckDistance();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _moveSpots[_randomSpot].position, _speed * Time.deltaTime); 
    }

    private void ChangeAnimation(bool isMoving)
    {
        _ememyAnimations.Walk(isMoving);
    }

    private void CheckDistance()
    {
        if (Vector2.Distance(transform.position, _moveSpots[_randomSpot].position) > _distance)
        {
            ChangeAnimation(true);
        }
        else 
        {
            if (_waitTime <= 0)
            {
                _randomSpot = Random.Range(0, _moveSpots.Length);
                _waitTime = _startWaitTime;
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
            ChangeAnimation(false);
        }
    }
}
