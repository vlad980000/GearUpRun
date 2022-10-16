using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int _timeBetwenShots;
    [SerializeField] private int _level;
    [SerializeField] private int _damage;

    [SerializeField] private bool _isBuyed;

    [SerializeField] private GameObject _model;

    [SerializeField] protected Bullet Bullet;

    [SerializeField] private Sprite _icon;

    public GameObject Model => _model;

    public int Damage => _damage;

    public int TimeBetwenShots => _timeBetwenShots;

    public bool IsBuyed => _isBuyed;

    public Sprite Image => _icon;

    public int Level => _level;

    public abstract void Shoot(Transform shootPoint);

    public void UpgradeDamage(int damage)
    {
        _damage += damage;
        _level++;
    }
}
