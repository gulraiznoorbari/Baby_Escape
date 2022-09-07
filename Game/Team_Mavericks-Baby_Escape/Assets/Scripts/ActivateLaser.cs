using UnityEngine;

public class ActivateLaser : MonoBehaviour
{
    [SerializeField] private LaserDetector _laserDetector;

    private Animator _animator;

    int PressedKey;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        int PressedKey = Animator.StringToHash("press");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            _animator.SetTrigger(PressedKey);
            _laserDetector.InitiateLaser();
            Debug.Log("Button Pressed and Laser Activated!");
        }
    }
}
