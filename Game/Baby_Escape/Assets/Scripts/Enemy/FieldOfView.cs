﻿using UnityEngine;
using System.Collections;

public class FieldOfView : MonoBehaviour
{
    [Range(0, 360)] public float _angle;
    [SerializeField] private GameObject _levelFailMenu;

    public GameObject _playerRef;
    public LayerMask _playerMask;
    public LayerMask _obstructionMask;

    public float _radius;
    public bool _CanSeePlayer;

    private void Start()
    {
        _playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVCoroutine());
    }

    private IEnumerator FOVCoroutine ()
    {       
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
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
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, _obstructionMask))
                {
                    _CanSeePlayer = true;
                    Handheld.Vibrate();
                    Destroy(gameObject);
                    _levelFailMenu.SetActive(true);
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
