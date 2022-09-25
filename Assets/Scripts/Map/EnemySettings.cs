using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel",menuName = "level/Create new level")]
public class EnemySettings : ScriptableObject
{
    [SerializeField] private Enemy _enemy;

    [SerializeField] private Prison _prison;

    [SerializeField] private int _enemyHealthPoints;
    [SerializeField] private int _enemyReward;
    [SerializeField] private int _enemyDamage;
    [SerializeField] private int _enemyCount;
    [SerializeField] private int _mapLenght;
    [SerializeField] private int _supportCount;

    public Enemy Enemy => _enemy;
    public int EnemyCount => _enemyCount;
    public int MapLenght => _mapLenght;
    public int SupportCount => _supportCount;
    public int EnemyHealth => _enemyHealthPoints;
    public int EnemyReward => _enemyReward;
    public int EnemyDamage => _enemyDamage;

}
