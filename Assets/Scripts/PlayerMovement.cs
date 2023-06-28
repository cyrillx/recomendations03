using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _respawnPosition;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _jumpForce;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            HorizontalMove(Vector3.right);
        }

        if (Input.GetKey(KeyCode.A))
        {
            HorizontalMove(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void HorizontalMove(Vector3 direction)
    {
        transform.Translate(_maxSpeed * Time.deltaTime * direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Coin>(out Coin pickedCoin))
        {
            Destroy(pickedCoin.gameObject);
        }

        if(collision.TryGetComponent<Enemy>(out Enemy touchedEnemy))
        {
            PlayerSpawn();
        }
    }

    private void PlayerSpawn()
    {
        transform.position = new Vector3(_respawnPosition.position.x, _respawnPosition.position.y);
    }
}
