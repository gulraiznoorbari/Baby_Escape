using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Touch _touch;
    private float _speed = 0.5f;

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
                Vector3 m_Input = new Vector3(
                    transform.position.x + _touch.deltaPosition.x,
                    transform.position.y, 
                    transform.position.z + _touch.deltaPosition.y);
                _rigidbody.MovePosition(transform.position + m_Input * Time.fixedDeltaTime * _speed);

                //Apply the movement vector to the current position, which is
                //multiplied by deltaTime and speed for a smooth MovePosition
                //_rigidbody.velocity = transform.position + m_Input;

                //transform.position = new Vector3(
                //    transform.position.x + _touch.deltaPosition.x * Time.fixedDeltaTime * _speed,
                //    transform.position.y,
                //    transform.position.z + _touch.deltaPosition.y * Time.fixedDeltaTime * _speed);
            }
        }
    }
}
