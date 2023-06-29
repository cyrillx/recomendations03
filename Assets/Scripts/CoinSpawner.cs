using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnCluster;
    [SerializeField] private GameObject _coinTemplate;

    private Transform[] _spawnPoints;
    private int _currentPoint;
    private Coin _coin;

    private void Start()
    {
        _spawnPoints = new Transform[_spawnCluster.childCount];

        for (int i = 0; i < _spawnPoints.Length; i++)
            _spawnPoints[i] = _spawnCluster.GetChild(i);

        SpawnNextCoin();
    }

    private void OnEnable()
    {
        if(_coin != null)
            _coin.PickedUp += SpawnNextCoin;
    }

    private void OnDisable()
    {
        if (_coin != null)
            _coin.PickedUp -= SpawnNextCoin;
    }

    public void SpawnNextCoin()
    {
        _coin = GameObject.Instantiate(_coinTemplate, _spawnPoints[_currentPoint].position, Quaternion.identity, transform).GetComponent<Coin>();
        _coin.PickedUp += SpawnNextCoin;

        _currentPoint++;

        if (_currentPoint == _spawnPoints.Length)
            _currentPoint = 0;
    }
}
