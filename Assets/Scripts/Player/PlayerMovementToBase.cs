using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementToBase : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private float _movementSpeed;

    [SerializeField] private Slider _moveToBaseSlider;

    [SerializeField] private PlayerMoveController _moveController;

    [SerializeField] private PLayerMovementOnBase _playerMoveOnBase;

    [SerializeField] private CinemachineVirtualCamera _cameraOffset;

    private Transform _target;

    private bool _baseIsReached;

    private void Start()
    {
        _cameraOffset.Priority = 11;
        _playerMoveOnBase.enabled = false;
        _baseIsReached = false;
        _moveToBaseSlider.gameObject.SetActive(true);
        _moveToBaseSlider.enabled = true;
        _moveController.enabled = true;
        _moveToBaseSlider.enabled = true;
    }

    private void Update()
    {
        if(_baseIsReached == false)
            MoveToBase();
        else
            JoysticActivated();
    }

    public void SetBaseIsReached()
    {
        if (_baseIsReached == false)
            _baseIsReached = true;
        else
            return;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void MoveToBase()
    {
        if (_target != null)
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + _movementSpeed * Time.deltaTime);
        else
            return;
    }

    private void JoysticActivated()
    {
        _cameraOffset.Priority = 9;
        _moveToBaseSlider.gameObject.SetActive(false);
        _moveController.enabled = false;
        _playerMoveOnBase.EnabledOn();
        enabled = false;
    }
}
