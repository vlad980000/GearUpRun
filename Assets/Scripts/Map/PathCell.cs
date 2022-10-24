using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PathCell : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [SerializeField] private float _playerDistance;

    private Player _player;

    public event UnityAction <PathCell> SpawnEnemyes;

    public Transform Start => _start;

    public Transform End => _end;

    private void Update()
    {
        if (_player != null)
        {
            CheckPLayerDistance();
        }
    }

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    private void CheckPLayerDistance()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) <= _playerDistance)
        {
            SpawnEnemyes?.Invoke(this);
            enabled = false;
        }
    }

    
}
