using UnityEngine;

public class LaserDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint; 

    private LineRenderer _laserline;
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _laserline = GetComponent<LineRenderer>();
        _particleSystem = GameObject.Find("startPoint").GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        _particleSystem.Stop();
    }

    public void InitiateLaser()
    {
        _laserline.startWidth = 0.2f;
        _laserline.endWidth = 0.2f;
        _laserline.SetPosition(0, _startPoint.position);
        _laserline.SetPosition(1, _endPoint.position);
        _particleSystem.Play();

        DetectMovingObjects();
    }

    private void DetectMovingObjects()
    {
        RaycastHit hit;
        float RaycastDistance = Vector3.Distance(_startPoint.position, _endPoint.position);
        Vector3 direction = _endPoint.transform.position - _startPoint.transform.position;
        // or you can simply use "transform.forward" for projecting in forward direction.

        if (Physics.Raycast(transform.position, direction, out hit, RaycastDistance, _layerMask))
        {
            if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("Enemy"))
            {
                Handheld.Vibrate();
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
