using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private ParticleSystem _bloodEffect;
    [SerializeField] private UnityEngine.Animator _animator;

    private MoveToTarget _mover;

    private int _healthPoint;
    private int _damage;
    private int _reward;

    private BoxCollider _collider;

    private Player _player;
    public Player Player => _player;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _bloodEffect.Stop();
        _mover = GetComponent<MoveToTarget>();
    }

    public void SetTarget(Player player)
    {
        _player = player;
    }

    public void AplyDamage(int damage)
    {
        if (damage >= _healthPoint)
        {
            Death();
            _colorChanger.ChangeColor();
            _bloodEffect.Play();
        }
        else
        {
            _healthPoint -= damage;
            _colorChanger.LoopChangeColor();
            _bloodEffect.Play();
        }
    }

    public void SetStats(int damage,int health,int reward)
    {
        _damage = damage;
        _healthPoint = health;
        _reward = reward;
    }

    public void Death()
    {
        _mover.enabled = false;
        _animator.SetTrigger("Death");
        _collider.enabled = false;
    }
}
