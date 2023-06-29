using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string AnimationRun = "isRun";

    public void StartRun()
    {
        _animator.SetBool(AnimationRun, true);
    }

    public void StopRun()
    {
        _animator.SetBool(AnimationRun, false);
    }
}
