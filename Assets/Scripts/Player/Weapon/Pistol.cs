using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;

    public override void Shoot()
    {
        Instantiate(_bullet, _shootPoint.position, Quaternion.identity).SetDamage(_damage);
    }
}
