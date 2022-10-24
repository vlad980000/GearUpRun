using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeaponShowcase : Showcase
{
    [SerializeField] private Weapon _weapon;

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
        if(other.TryGetComponent(out Player player))
        {
            if(player.GetComponent<PLayerMovementOnBase>().IsMoving == false)
                StartCoroutine(PassMoney(player));
        }
    }

    public override void StartAnimation()
    {
        var weapon = Instantiate(_weapon, _goodsPosition.transform.position,Quaternion.identity);
        Tween tween = weapon.transform.DORotate(new Vector3(0f,360f,0f), _animationDuration,RotateMode.FastBeyond360);

        tween.SetEase(Ease.Linear).SetLoops(-1);
    }

    private void UpgradeWeapon(Player player)
    {
        player.UpgradeWeapon(_weapon,_upgradeValue);
    }

    private IEnumerator PassMoney(Player player)
    {
        _currentCostUpgrade += _coroutineValue;

        player.PussMoney(_coroutineValue);

        if(_currentCostUpgrade == _upgradeValue)
            UpgradeWeapon(player);

        yield return null;
        yield break;
    }
}
