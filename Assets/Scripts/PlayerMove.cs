using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _respawnPoition;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private UnityEvent _pickedUp;
    [SerializeField] private Animator _animator;

    private float _speed = 0;
    private bool isLeftDirected;

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
            isLeftDirected = false;
            startRun();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            isLeftDirected = true;
            startRun();
        }
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            stopRun();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump!");
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void startRun()
    {
        _spriteRenderer.flipX = isLeftDirected;
        _animator.SetBool("isRun", true);
    }

    private void stopRun()
    {
        _animator.SetBool("isRun", false);
    }

    private void HorizontalMove(float direction)
    {
        _speed = _maxSpeed * Time.deltaTime;
        transform.Translate(_speed * direction, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            _pickedUp.Invoke();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Respawn();
        }
    }
    private void Respawn()
    {
        transform.position = new Vector3(_respawnPoition.position.x, _respawnPoition.position.y);
    }
}
