using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnCluster;
    [SerializeField] private GameObject _coinTemplate;

    private Transform[] _spawnPoints;
    private int _currentPoint;

    private void Start()
    {
        _spawnPoints = new Transform[_spawnCluster.childCount];
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = _spawnCluster.GetChild(i);
        }
        SpawnNextCoin();
    }

    public void SpawnNextCoin()
    {
        GameObject.Instantiate(_coinTemplate, _spawnPoints[_currentPoint].position, Quaternion.identity, transform);
        _currentPoint++;
        if(_currentPoint == _spawnPoints.Length)
            _currentPoint = 0;
    }
}
