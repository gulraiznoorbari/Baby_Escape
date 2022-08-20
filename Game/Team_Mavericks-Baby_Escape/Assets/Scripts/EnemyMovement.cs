using UnityEngine;
using DG.Tweening;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    //[SerializeField] private Transform StartPoint;
    //[SerializeField] private Transform EndPoint;
    //[SerializeField] private float LerpSpeed = 1f;
    //[SerializeField] private float _rotationSpeed = 40f;
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
            .Append(transform.DOMoveX(3, 1f))
            .Append(transform.DORotate(new Vector3(0, 180, 0), 0.5f, RotateMode.FastBeyond360))
            .Append(transform.DOMoveX(-3.25f, 1f))
            .Append(transform.DORotate(new Vector3(0, 0, 0), 0.5f, RotateMode.FastBeyond360))
            .SetEase(Ease.Linear)
            .SetLoops(-1);
    }

    // Movement Using Lerp() and Coroutine:

    //private void Start()
    //{
    //    StartCoroutine(LerpRectFixedTime());
    //}

    //private IEnumerator LerpRectFixedTime()
    //{
    //    _rigidbody.transform.rotation = Quaternion.identity;

    //    while (true)
    //    {
    //        float time = 0;
    //        while (time < 1)
    //        {
    //            _rigidbody.transform.position = Vector3.Lerp(StartPoint.position, EndPoint.position, time);
    //            transform.rotation = Quaternion.Slerp(transform.rotation, StartPoint.rotation, _rotationSpeed * Time.fixedDeltaTime * 360);
    //            time += Time.deltaTime * LerpSpeed;
    //            yield return null;
    //        }

    //        time = 0;
    //        while (time < 1)
    //        {
    //            _rigidbody.transform.position = Vector3.Lerp(EndPoint.position, StartPoint.position, time);
    //            transform.rotation = Quaternion.Slerp(transform.rotation, EndPoint.rotation, _rotationSpeed * Time.fixedDeltaTime * 360);
    //            time += Time.deltaTime * LerpSpeed;
    //            yield return null;
    //        }
    //    }
    //}
}
