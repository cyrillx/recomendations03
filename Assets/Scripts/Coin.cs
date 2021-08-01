using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private CoinSpawner _coinSpawner;

    private void Start()
    {
        _coinSpawner = gameObject.GetComponentInParent<CoinSpawner>();
    }

    private void OnDestroy()
    {
        //_coinSpawner.SpawnNextCoin();
    }
}
