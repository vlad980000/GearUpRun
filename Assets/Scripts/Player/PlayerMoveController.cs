using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private Player _playerMovement;

    [SerializeField] private float _maxX;
    [SerializeField] private float _minX;

    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.value = 0.5f;
    }

    public void SetNormalizedPosition(float position)
    {
        _playerMovement.transform.position = Vector3.Lerp(new Vector3(_minX, _playerMovement.transform.position.y, _playerMovement.transform.position.z), new Vector3(_maxX, _playerMovement.transform.position.y, _playerMovement.transform.position.z), position);
    }
}
