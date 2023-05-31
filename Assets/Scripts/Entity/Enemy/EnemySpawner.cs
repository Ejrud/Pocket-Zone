using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _enemyCount;
    [SerializeField] private List<Transform> _positions = new List<Transform>();
    [SerializeField] private GameObject _enemyPrefab;

    private void Start()
    {
        if (_enemyCount > _positions.Count)
            _enemyCount = _positions.Count;
        
        for (int i = 0; i < _enemyCount; i++)
        {
            int indexPosition = Random.Range(0, _positions.Count);
            Transform randTr = _positions[indexPosition];
            Instantiate(_enemyPrefab, randTr.position, Quaternion.identity);
            _positions.Remove(randTr);
        }
    }
}
