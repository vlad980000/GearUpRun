using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    [SerializeField] private PathCell _prefub;

    [SerializeField] private Base _base;

    [SerializeField] private PlayerMovement _movementTarget;

    [SerializeField] private Player _player;

    [SerializeField] private float _spawnRadius;

    private List<Enemy> _enemyList;

    private List<PathCell> _pathCells;

    private Vector3 _startPosition;

    private Base _targetBase;

    private int _spawnIndex;

    private void Awake()
    {
        _enemyList = new List<Enemy>();
        _pathCells = new List<PathCell>();
    }

    private void Start()
    {
        _startPosition = Vector3.zero;
    }

    public void CreateMap(int mapLenght,Enemy enemy, int enemyHealth, int enemyDamage, int enemyReward,int enemyCount)
    {
        CleanMap();

        _spawnIndex = enemyCount;

        Vector3 vector3 = new Vector3(0f, 0f, _prefub.transform.position.z * 2);

        for (int i = 0; i < mapLenght; i++)
        {
            if(i == 0)
            {
                _pathCells.Add(Instantiate(_prefub,_startPosition,Quaternion.identity));
            }
            else
            {
                var pathCell = Instantiate(_prefub,_startPosition + vector3 * i,Quaternion.identity);
                _pathCells.Add(pathCell);
                CreateEnemyes(enemy,pathCell.transform.position,enemyHealth,enemyDamage,enemyReward,enemyCount);
            }
        }

        for (int i = 0; i < _pathCells.Count; i++)
        {
            _pathCells[i].SpawnEnemyes += OnSpawnEnemyes;
            Debug.Log("подписываюсь");
        }

        SetPLayer();
        _targetBase = Instantiate(_base,_startPosition + vector3 * (mapLenght), Quaternion.identity);
        _movementTarget.SetTarget(_targetBase.transform);
    }

    private void CreateEnemyes(Enemy enemy,Vector3 spawnPoint,int enemyHealth,int enemyDamage,int enemyReward,int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            var newEnemy = Instantiate(enemy, GetRandomPoint(spawnPoint), Quaternion.identity);
            newEnemy.SetTarget(_player);
            newEnemy.SetStats(enemyDamage, enemyDamage, enemyReward);
            newEnemy.gameObject.SetActive(false);
            _enemyList.Add(newEnemy);
        }
    }

    private void CleanMap()
    {
        if(_pathCells.Count > 0)
        {
            for (int i = 0; i < _pathCells.Count; i++)
            {
                Destroy(_pathCells[i]);
            }
        }
        else
        {
            return;
        }
    }

    private Vector3 GetRandomPoint(Vector3 point)
    {
        return new Vector3(point.x + (Random.insideUnitSphere.x * _spawnRadius),point.y, point.z + (Random.insideUnitSphere.z * _spawnRadius));
    }

    private void SetPLayer()
    {
        for (int i = 1; i < _pathCells.Count - 1; i++)
        {
            _pathCells[i].SetPlayer(_player);
        }
    }

    private void OnSpawnEnemyes(PathCell pathCell)
    {
        for (int i = 0; i < _spawnIndex; i++)
        {
            for (int f = 0; f < 1; f++)
            {
                _enemyList[i].transform.position = GetRandomPoint(pathCell.transform.position);
                _enemyList[i].gameObject.SetActive(true);
                _enemyList.Remove(_enemyList[i]);
            }
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _pathCells.Count; i++)
        {
            _pathCells[i].SpawnEnemyes -= OnSpawnEnemyes;
            Debug.Log("отписываюсь");
        }
    }
}
