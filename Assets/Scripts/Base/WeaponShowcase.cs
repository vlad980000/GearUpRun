using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeaponShowcase : Showcase
{
    [SerializeField] private Pistol _weapon;

    [SerializeField] private float _animationDuration;

    [SerializeField] private int _upgradeValue;

    [SerializeField] private int _startCostUpgrade;

    [SerializeField] private int _coroutineValue;

    private int _currentCostUpgrade = 0;

    private BoxCollider _collider;

    private Player _player;

    private Coroutine _coroutine;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        StartAnimation();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<Player>().GetComponent<PLayerMovementOnBase>().IsMoving == false)
        {
            StartCoroutine(PassMoney(other.GetComponent<Player>().PussMoney(_coroutineValue)));
        }
    }

    public override void StartAnimation()
    {
        var weapon = Instantiate(_weapon, _goodsPosition.transform.position,Quaternion.identity);
        Tween tween = weapon.transform.DORotate(new Vector3(0f,360f,0f), _animationDuration,RotateMode.FastBeyond360);

        tween.SetEase(Ease.Linear).SetLoops(-1);
    }

    private void UpgradeWeapon()
    {
        for (int i = 0; i < _player.Weapons.Length; i++)
        {
            if(_player.Weapons[i] == _weapon)
                _player.Weapons[i].UpgradeDamage(_upgradeValue);
        }
    }

    private IEnumerator PassMoney(int value)
    {
        _currentCostUpgrade += value;

        if(_currentCostUpgrade == _upgradeValue)
        {
            UpgradeWeapon();
        }
        yield return null;
        yield break;
    }
}
