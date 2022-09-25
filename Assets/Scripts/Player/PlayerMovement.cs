using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private float _movementSpeed;

    private Transform _target;

    private void Update()
    {
        if (_target != null)
            transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z + _movementSpeed * Time.deltaTime);
        else
            return;

    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
