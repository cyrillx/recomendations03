using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _respawnPosition;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _jumpForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Coin>(out Coin pickedCoin))
        {
            Destroy(pickedCoin.gameObject);
        }

        if(collision.TryGetComponent<Enemy>(out Enemy touchedEnemy))
        {
            SpawnPlayer();
        }
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce);
    }

    public void MoveHorizontal(Vector3 direction)
    {
        transform.Translate(_maxSpeed * Time.deltaTime * direction);
    }

    private void SpawnPlayer()
    {
        transform.position = new Vector3(_respawnPosition.position.x, _respawnPosition.position.y);
    }
}
