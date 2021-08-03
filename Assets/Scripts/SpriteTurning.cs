using UnityEngine;

public class SpriteTurning : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Vector3 _lastPosition;
    private bool _isTurnedLeft;

    private void Start()
    {
        _isTurnedLeft = false;
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _lastPosition = gameObject.transform.position;
    }

    private void Update()
    {
        Vector3 newPosition = gameObject.transform.position;
        if (_lastPosition.x == newPosition.x) return;

        bool isMovedLeft = _lastPosition.x > newPosition.x;
        if(_isTurnedLeft != isMovedLeft)
        {
            _isTurnedLeft = isMovedLeft;
            _spriteRenderer.flipX = _isTurnedLeft;
        }
        _lastPosition = newPosition;
    }
}
