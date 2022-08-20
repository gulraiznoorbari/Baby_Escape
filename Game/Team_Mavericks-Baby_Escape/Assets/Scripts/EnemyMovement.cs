using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Sequence _sequence;

    // Movement Using Tweening:
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        PlayEnemyMovementSequence();
    }

    private void PlayEnemyMovementSequence()
    {
        _sequence?.Kill();

        _sequence = DOTween.Sequence()
            .Append(transform.DOMoveX(3, 1.5f))
            .Append(transform.DORotate(new Vector3(0, 180, 0), 0.7f, RotateMode.FastBeyond360))
            .Append(transform.DOMoveX(-3.3f, 1.5f))
            .Append(transform.DORotate(new Vector3(0, 0, 0), 0.7f, RotateMode.FastBeyond360))
            .SetEase(Ease.Linear)
            .SetLoops(-1);
    }
}
