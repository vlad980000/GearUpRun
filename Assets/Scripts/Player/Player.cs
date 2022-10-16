using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon[] _weapons;
    [SerializeField] private Transform _weaponTransform;

    [SerializeField] private int _money;

    private PlayerMoveController _moveController;
    private PlayerMovementToBase _playerMovement;

    private Weapon _currentWeapon;

    private Base _base;

    private Coroutine _shoot;

    public Weapon[] Weapons => _weapons;

    public int Money => _money;

    public UnityAction <int>MoneyIsChanged;

    private void Start()
    {
        _moveController = GetComponent<PlayerMoveController>();
        _playerMovement = GetComponent<PlayerMovementToBase>();
        TakeStartWeapon();
    }

    public int PussMoney(int value)
    {
        if(_money >= value)
        {
            _money -= value;
            MoneyIsChanged?.Invoke(_money);
            return value;
        }
        return 0;
    }

    public void SetBase(Base maineBase)
    {
        _base = maineBase;
    }

    private void TakeStartWeapon()
    {
        if(_currentWeapon == null)
        {
            _currentWeapon = _weapons[0];
            Instantiate(_currentWeapon.Model,_weaponTransform);
            StartShootCoroutine();
        }
        else
        {
            return;
        }
    }

    private void StartShootCoroutine()
    {
        _shoot = StartCoroutine(Shoot(_currentWeapon.TimeBetwenShots));
    }

    private IEnumerator Shoot(int shootDelay)
    {
        var dealay = new WaitForSeconds(shootDelay);

        if(_currentWeapon != null)
        {
            while(_currentWeapon != null)
            {
                _currentWeapon.Shoot(_weaponTransform);

                yield return dealay;
            }
        }
        yield break;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Base>() == _base)
        {
            _playerMovement.SetBaseIsReached();
            StopCoroutine(_shoot);
        }
    }
}
