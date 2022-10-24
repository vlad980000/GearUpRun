using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PLayerMovementOnBase : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private float _movementSpeed;

    [SerializeField] private CinemachineVirtualCamera _cameraOffset;

    [SerializeField] private UnityEngine.Animator _animator;

    private Rigidbody _rigidbody;

    private BoxCollider _boxCollider;

    private bool _isCanMove = false;
    private bool _isMoving;

    private Vector3 _direction;

    public bool IsMoving => _isMoving;

    public UnityEvent<bool> ValueIsChanhed;

    private void Start()
    {
        _animator.SetLayerWeight(1, 2);
        _cameraOffset.Priority = 10;
        _boxCollider = GetComponent<BoxCollider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _direction = new Vector3(_joystick.Horizontal / _movementSpeed, 0, _joystick.Vertical / _movementSpeed);

        if (_isCanMove == true)
        {
            transform.position += _direction;

            if(_joystick.Horizontal!=0 && _joystick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(_direction);
                _animator.SetBool("isMoving", true);
                _isMoving = true;

                ValueIsChanhed?.Invoke(_isMoving);
            }
            else
            {
                _animator.SetBool("isMoving", false);
                _isMoving = false;

                ValueIsChanhed?.Invoke(_isMoving);
            }
        }
        else
        {
            return;
        }
    }

    public void EnabledOn()
    {
        enabled = true;
        _joystick.gameObject.SetActive(true);
        _isCanMove = true;
        _cameraOffset.Priority = 11;
    }
}
