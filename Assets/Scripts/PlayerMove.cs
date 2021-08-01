using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _respawnPoition;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private UnityEvent _pickedUp;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            HorizontalMove(1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            HorizontalMove(-1f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump!");
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void HorizontalMove(float direction)
    {
        transform.Translate(_speed * Time.deltaTime * direction, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coin coin = collision.gameObject.GetComponent<Coin>();
        if (coin != null)
        {
            Debug.Log("Collider!");
            _pickedUp.Invoke();
            Destroy(coin.gameObject);
        }
        PatrolMovement enemy = collision.gameObject.GetComponent<PatrolMovement>();
        if(enemy != null)
        {
            Respawn();
        }
    }
    private void Respawn()
    {
        transform.position = new Vector3(_respawnPoition.position.x, _respawnPoition.position.y);
    }
}
