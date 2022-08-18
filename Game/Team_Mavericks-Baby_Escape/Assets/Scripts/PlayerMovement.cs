using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Touch _touch;
    private float _speed = 10f;
    private float _rotationSpeed = 720;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if(_touch.phase == TouchPhase.Moved)
            {
                Vector3 _movementDirection = new Vector3(
                    transform.position.x + _touch.deltaPosition.x,
                    transform.position.y, 
                    transform.position.z + _touch.deltaPosition.y);
                
                // Rigidbody.MovePosition() takes position in world space as parameter, not direction.
                // World space position is basically what transform.position is.
                Vector3 smoothedDelta = Vector3.MoveTowards(transform.position, _movementDirection, Time.fixedDeltaTime * _speed);
                _rigidbody.MovePosition(smoothedDelta);

                Vector3 newDirection = Vector3.RotateTowards(transform.forward, _movementDirection, _rotationSpeed * Time.fixedDeltaTime, 0f);
                transform.rotation = Quaternion.LookRotation(newDirection);
                
                //Quaternion toRotation = Quaternion.LookRotation(_movementDirection, Vector3.up);
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.fixedDeltaTime);
            }
        }
    }
}
