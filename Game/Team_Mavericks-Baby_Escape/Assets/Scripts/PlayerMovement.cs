using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private Touch _touch;

    int isRunningKey;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();

        isRunningKey = Animator.StringToHash("isRunning");
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            _animator.SetBool(isRunningKey, true);
            if(_touch.phase == TouchPhase.Moved)
            {
                Vector3 _movementDirection = new Vector3(
                    transform.position.x + _touch.deltaPosition.x,
                    transform.position.y, 
                    transform.position.z + _touch.deltaPosition.y);

                // Rigidbody.MovePosition() takes position in world space as parameter, not direction.
                // World space position is basically what transform.position is.
                _rigidbody.MovePosition(Vector3.MoveTowards(transform.position, _movementDirection, Time.fixedDeltaTime * _speed));

                //Rotate towards the direction of the movement (w/ slerp):
                _rigidbody.transform.rotation = Quaternion.Slerp(
                    _rigidbody.transform.rotation,
                    Quaternion.LookRotation(_movementDirection),
                    Time.fixedDeltaTime * _rotationSpeed);
                _animator.SetBool(isRunningKey, true);
            }
            else if (_touch.phase == TouchPhase.Ended)
            {
                _animator.SetBool(isRunningKey, false);
            }
        }
        else if (Input.touchCount <= 0)
        {
            _animator.SetBool(isRunningKey, false);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Collectible"))
        {
            StartCoroutine(Restart());
        }
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
