using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private ParticleSystem _bloodEffect;
    [SerializeField] private Animator _animator;

    private int _healthPoint;
    private int _damage;
    private int _reward;

    private Player _player;
    public Player Player => _player;

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
        _animator.SetBool();
    }
}
