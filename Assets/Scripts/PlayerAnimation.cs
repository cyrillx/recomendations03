using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private const string AnimationRun = "isRun";

    [SerializeField] private Animator _animator;

    public void StartRun()
    {
        _animator.SetBool(AnimationRun, true);
    }

    public void StopRun()
    {
        _animator.SetBool(AnimationRun, false);
    }
}
