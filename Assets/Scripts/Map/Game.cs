using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private static int _levelIndex = 0;

    [SerializeField] private Player _player;
    [SerializeField] private MapCreator _mapCreator;
    [SerializeField] private List<EnemySettings> _enemySettings;

    private EnemySettings _currentLevel;
    private EnemySettings _startLevel;

    private void Start()
    {
        _startLevel = _enemySettings[_levelIndex];

        if (_currentLevel == null)
            _currentLevel = _startLevel;

        ResetLevel();
    }

    public void SetNextLevel()
    {
        if(_levelIndex < _enemySettings.Count)
        {
            _levelIndex++;
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            Debug.Log("Вы прошли игру");
        }
    }

    private void ResetLevel()
    {
        _mapCreator.CreateMap(_currentLevel.MapLenght,_currentLevel.Enemy,_currentLevel.EnemyHealth, _currentLevel.EnemyDamage, _currentLevel.EnemyReward,_currentLevel.EnemyCount);
        _player.transform.position = Vector3.zero + new Vector3(0,0,0);    
    }
}
