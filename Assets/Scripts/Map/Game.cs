using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private MapCreator _mapCreator;
    [SerializeField] private List<EnemySettings> _enemySettings;

    private EnemySettings _currentLevel;
    private EnemySettings _startLevel;

    private void Start()
    {
        _startLevel = _enemySettings[0];

        if (_currentLevel == null)
            _currentLevel = _startLevel;

        ResetLevel();
    }

    private void ResetLevel()
    {
        _mapCreator.CreateMap(_currentLevel.MapLenght,_currentLevel.Enemy,_currentLevel.EnemyHealth, _currentLevel.EnemyDamage, _currentLevel.EnemyReward,_currentLevel.EnemyCount);
        _player.transform.position = Vector3.zero;    
    }
}
