using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPointsCoin;
    [SerializeField] private Coin _coin;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1);

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        for(int i = 0; i < _spawnPointsCoin.Length; i++)
        {
            Instantiate(_coin, _spawnPointsCoin[i].transform.position, Quaternion.identity);

            yield return _waitForSeconds;
        }
    }
}
