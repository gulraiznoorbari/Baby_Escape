using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    //[SerializeField] private float Step = 2;
    //[SerializeField] private Vector3 Direction = new Vector3(5,0,0);
    //[SerializeField] private float MovementSpeed;
    //[SerializeField] private float RaycastDistance = 2f;
    //[SerializeField] private LayerMask LayerMask;
    [SerializeField] private Transform StartPoint;
    [SerializeField] private Transform EndPoint;
    [SerializeField] private float LerpSpeed = 1f;
    [SerializeField] private float _rotationSpeed = 40f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        //Vector3 _currentAngles = transform.rotation.eulerAngles;
    }

    private void Start()
    {
        StartCoroutine(LerpRectFixedTime());
    }

    private IEnumerator LerpRectFixedTime()
    {
        _rigidbody.transform.rotation = Quaternion.identity;

        while (true)
        {
            float time = 0;
            while (time < 1)
            {
                _rigidbody.transform.position = Vector3.Lerp(StartPoint.position, EndPoint.position, time);
                transform.rotation = Quaternion.Slerp(transform.rotation, StartPoint.rotation, _rotationSpeed * Time.fixedDeltaTime);
                time += Time.deltaTime * LerpSpeed;
                yield return null;
            }

            time = 0;
            while (time < 1)
            {
                _rigidbody.transform.position = Vector3.Lerp(EndPoint.position, StartPoint.position, time);
                transform.rotation = Quaternion.Slerp(transform.rotation, EndPoint.rotation, _rotationSpeed * Time.fixedDeltaTime);
                time += Time.deltaTime * LerpSpeed;
                yield return null;
            }
        }
    }

    //private void FixedUpdate()
    //{
    //    var step = Step * Time.fixedDeltaTime;
    //    var nextposition = transform.position + (Direction * step);
    //    nextposition = Vector3.Lerp(transform.position, nextposition, MovementSpeed * Time.fixedDeltaTime);
    //    _rigidbody.MovePosition(nextposition);

    //    //DetectObjectThroughRaycast();
    //}

    //private void DetectObjectThroughRaycast()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, Direction, out hit, RaycastDistance, LayerMask))
    //    {
    //        if (hit.collider.CompareTag("Wall"))
    //        {
    //            RotateObject();
    //            StopMovement();
    //        }
    //    }
    //}

    //private void StopMovement()
    //{
    //    _rigidbody.velocity = Vector3.zero;
    //}

    //private void RotateObject()
    //{
    //    Debug.Log(transform.rotation.eulerAngles);

    //    Vector3 to = new Vector3(0, 180, 0);
    //    Vector3 v3current = Vector3.Lerp(_currentAngles, to, _rotationSpeed * Time.fixedDeltaTime);
    //    transform.eulerAngles = v3current;

    //    transform.rotation = Quaternion.Slerp(transform.rotation, otherObject.rotation, _rotationSpeed * Time.fixedDeltaTime);

    //    Debug.Log("Object Rotated!");
    //    Debug.Log(transform.rotation.eulerAngles);
    //}
}
