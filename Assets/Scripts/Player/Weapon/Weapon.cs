using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int _damage;

    [SerializeField] protected float _timeBetwenShots;

    [SerializeField] protected bool _isBuyed;

    public abstract void Shoot();

    private IEnumerator ShootDelay()
    {
        var shootDelay = new WaitForSeconds(_timeBetwenShots);

        while (true)
        {
            Shoot();

            yield return shootDelay;
        }
    }

    private void OnEnable()
    {
        StartCoroutine(ShootDelay());
    }

    private void OnDisable()
    {
        StopCoroutine(ShootDelay());
    }
}
