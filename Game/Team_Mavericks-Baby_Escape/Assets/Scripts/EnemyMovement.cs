using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rigidbody;
    private Sequence _sequence;

    private static int IdleKey = Animator.StringToHash("Idle");
    private static int WalkingKey = Animator.StringToHash("Walking");
    private static int RotatingKey = Animator.StringToHash("Rotating");

    // Movement Using Tweening:
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        PlayEnemyMovementSequence();
    }

    private void PlayEnemyMovementSequence()
    {
        _sequence?.Kill();

        _sequence = DOTween.Sequence()
            .AppendCallback(PlayIdleAnimation)
            .AppendCallback(PlayWalkAnimation)
            .Join(transform.DOMoveX(3.3f, 2.5f))
            .AppendCallback(PlayRotateAnimation)
            .Join(transform.DORotate(new Vector3(0, 270, 0), 0.6f, RotateMode.FastBeyond360))
            .AppendCallback(PlayWalkAnimation)
            .Join(transform.DOMoveX(-3.3f, 2.5f))
            .AppendCallback(PlayRotateAnimation)
            .Join(transform.DORotate(new Vector3(0, 90, 0), 0.6f, RotateMode.FastBeyond360))
            .SetEase(Ease.Linear)
            .SetLoops(-1);
    }

    private void PlayIdleAnimation()
    {
        _animator.SetTrigger(IdleKey);
    }
    private void PlayWalkAnimation()
    {
        _animator.SetTrigger(WalkingKey);
    }
    private void PlayRotateAnimation()
    {
        _animator.SetTrigger(RotatingKey);
    }
}
