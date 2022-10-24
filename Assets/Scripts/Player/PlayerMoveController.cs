using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private Player _playerMovement;

    [SerializeField] private float _maxX;
    [SerializeField] private float _minX;

    [SerializeField] private FixedJoystick _fixedJoystick;

    public void SetNormalizedPosition(float position)
    {
        _playerMovement.transform.position += new Vector3(_fixedJoystick.Horizontal,0,0);
    }
}
