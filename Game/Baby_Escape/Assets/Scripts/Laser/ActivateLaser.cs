using UnityEngine;
using System.Collections;

public class ActivateLaser : MonoBehaviour
{
    [SerializeField] private LaserDetector _laserDetector;

    private Animator _animator;

    private static int PressedKey = Animator.StringToHash("press");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    private void FixedUpdate()
    {
        _laserDetector.DetectMovingObjects();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            _animator.SetTrigger(PressedKey);
            FindObjectOfType<AudioManager>().Play("Laser_Switch");
            StartCoroutine(intializeLaser());
        }
    }

    private IEnumerator intializeLaser()
    {
        yield return new WaitForSeconds(0.2f);
        _laserDetector.InitiateLaser();
    }
}
