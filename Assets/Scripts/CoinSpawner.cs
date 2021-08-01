using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnCluster;
    [SerializeField] private GameObject _coinTemplate;

    private int _currentPoint;
    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_spawnCluster.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _spawnCluster.GetChild(i);
        }
        //SpawnNextCoin();
    }

    public void SpawnNextCoin()
    {
        //GameObject.Instantiate(_coinTemplate, _points[_currentPoint].position, Quaternion.identity);

        if(_currentPoint == _points.Length)
            _currentPoint = 0;
    }
}
