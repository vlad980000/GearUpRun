using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    
    private Vector3 _target;

    [SerializeField] private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _target = _enemy.Player.transform.position;
    }

    private void Update()
    {
        _target = _enemy.Player.transform.position;

        if (_target != null)
            _navMeshAgent.SetDestination(_target);
    }
}
