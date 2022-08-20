using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Touch _touch;
    private float _speed = 5f;
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
            if(_touch.phase == TouchPhase.Stationary || _touch.phase == TouchPhase.Moved)
            {
                Vector3 _movementDirection = new Vector3(
                    transform.position.x + _touch.deltaPosition.x,
                    transform.position.y, 
                    transform.position.z + _touch.deltaPosition.y).normalized;
                
                // Rigidbody.MovePosition() takes position in world space as parameter, not direction.
                // World space position is basically what transform.position is.
                _rigidbody.MovePosition(Vector3.MoveTowards(transform.position, _movementDirection, Time.fixedDeltaTime * _speed));

                Quaternion toRotation = Quaternion.LookRotation(_movementDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.fixedDeltaTime);

                //rotate towards the direction of the movement
                //transform.rotation = Quaternion.LookRotation(_movementDirection);
            }
        }
    }
}
