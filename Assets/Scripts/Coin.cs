﻿using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    private UnityEvent _pickedUp = new UnityEvent();

    public event UnityAction PickedUp
    {
        add => _pickedUp.AddListener(value);
        remove => _pickedUp.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            _pickedUp.Invoke();
        }
    }
}
