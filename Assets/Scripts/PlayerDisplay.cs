using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisplay : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;

    private bool _isTurnedLeft;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _isTurnedLeft = false;
            StartRun();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _isTurnedLeft = true;
            StartRun();
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            StopRun();
        }
    }

    private void StartRun()
    {
        _spriteRenderer.flipX = _isTurnedLeft;
        _animator.SetBool("isRun", true);
    }

    private void StopRun()
    {
        _animator.SetBool("isRun", false);
    }
}
