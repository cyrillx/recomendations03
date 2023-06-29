using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private PlayerMovement _playerMovement;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            _playerAnimation.StartRun();

        if (Input.GetKeyDown(KeyCode.A))
            _playerAnimation.StartRun();

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            _playerAnimation.StopRun();

        if (Input.GetKey(KeyCode.D))
            _playerMovement.MoveHorizontal(Vector3.right);

        if (Input.GetKey(KeyCode.A))
            _playerMovement.MoveHorizontal(Vector3.left);

        if (Input.GetKeyDown(KeyCode.Space))
            _playerMovement.Jump();
    }
}
