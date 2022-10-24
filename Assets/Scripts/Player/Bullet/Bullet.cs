using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private int _damage;

    private float _lifeTime;
    private float _time = 0;

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.Self);

        _time += Time.deltaTime;

        if( _time > _lifeTime )
            Destroy(gameObject);
    }

    public void SetStats(int damage, float lifeTime)
    {
        _damage = damage;
        _lifeTime = lifeTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.AplyDamage(_damage);
        }
    }
}
