using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartRun();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartRun();
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            StopRun();
        }
    }

    private void StartRun()
    {
        _animator.SetBool("isRun", true);
    }

    private void StopRun()
    {
        _animator.SetBool("isRun", false);
    }
}
