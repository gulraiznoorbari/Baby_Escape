using UnityEngine;

public class LaserLineController : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    private LineRenderer _laserline;

    // Start is called before the first frame update
    void Start()
    {
        _laserline = GetComponent<LineRenderer>();
        //_laserline.SetWidth(0.2f, 0.2f);
        _laserline.startWidth = 0.2f;
        _laserline.endWidth = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        _laserline.SetPosition(0, _startPoint.position);
        _laserline.SetPosition(1, _endPoint.position);
    }
}
