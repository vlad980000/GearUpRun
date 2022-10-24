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
    private PLayerMovementOnBase _playerMovementOnBase;

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
        _playerMovementOnBase = GetComponent<PLayerMovementOnBase>();
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

    public void UpgradeWeapon(Weapon weapon, int damage)
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            if(_weapons[i] == weapon)
            {
                if(_weapons[i].IsBuyed == false)
                    _weapons[i].Buy();
                else
                    _weapons[i].UpgradeDamage(damage);
            }
        }
    }

    public void SetWeapon(Weapon weapon)
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            if (_weapons[i] == weapon)
            {

                if(_currentWeapon != null)
                    Destroy(_currentWeapon.gameObject);

                _currentWeapon = Instantiate(_weapons[i], _weaponTransform);

                if (_shoot != null)
                {
                    StopCoroutine(_shoot);
                    StartShootCoroutine();
                }
                else
                {
                    StartShootCoroutine();
                }    
            }
        }
    }

    private void TakeStartWeapon()
    {
        if(_currentWeapon == null)
        {
            SetWeapon(_weapons[0]);
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

    private IEnumerator Shoot(float shootDelay)
    {
        var dealay = new WaitForSeconds(shootDelay);

        if(_currentWeapon != null)
        {
            while(_currentWeapon != null)
            {
                yield return dealay;
                _currentWeapon.Shoot(_weaponTransform);
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
