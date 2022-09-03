using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FieldOfView : MonoBehaviour
{
    [Range(0, 360)] public float _angle;
    public float _radius;
    public GameObject _playerRef;
    public LayerMask _playerMask;
    public bool _CanSeePlayer;

    private void Start()
    {
        _playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVCoroutine());
    }

    private IEnumerator FOVCoroutine ()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while(true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, _radius, _playerMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            // Direction of Target:
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            // Angle of Target:
            if (Vector3.Angle(transform.forward, directionToTarget) < _angle / 2)
            {
                // Distance from target:
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                // Player Detection through Raycast:
                if (Physics.Raycast(transform.position, directionToTarget, distanceToTarget, _playerMask))
                {
                    _CanSeePlayer = true;
                    //Debug.Log("Player Spotted!");
                    Handheld.Vibrate();
                    Destroy(gameObject);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }

                else
                    _CanSeePlayer = false;

            }
            else
                _CanSeePlayer = false;
        }
        else if (_CanSeePlayer)
            _CanSeePlayer = false;
    }
}
