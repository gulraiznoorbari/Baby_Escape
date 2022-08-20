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

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

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
