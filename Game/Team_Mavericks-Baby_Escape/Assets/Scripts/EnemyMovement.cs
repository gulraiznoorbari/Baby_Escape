using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rigidbody;
    private Sequence _sequence;

    [SerializeField] private Vector3 _endPositionA;
    [SerializeField] private Vector3 _endPositionB;
    [SerializeField] private float _movementDuration;
    [Range(0,360)] [SerializeField] private float _rotationAngleA;
    [Range(0,360)] [SerializeField] private float _rotationAngleB;
    [Range(0, 1)] [SerializeField] private float _rotationDuration;

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
            .Join(transform.DOMove(_endPositionA, _movementDuration))
            .AppendCallback(PlayRotateAnimation)
            .Join(transform.DORotate(new Vector3(0, _rotationAngleA, 0), _rotationDuration, RotateMode.FastBeyond360))
            .AppendCallback(PlayWalkAnimation)
            .Join(transform.DOMove(_endPositionB, _movementDuration))
            .AppendCallback(PlayRotateAnimation)
            .Join(transform.DORotate(new Vector3(0, _rotationAngleB, 0), _rotationDuration, RotateMode.FastBeyond360))
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
