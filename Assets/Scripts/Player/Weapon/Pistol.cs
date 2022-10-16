using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : Weapon
{
    private void Update()
    {
        Debug.Log(Damage);
    }
    public override void Shoot(Transform shootPoint)
    {
        var bullet = Instantiate(Bullet, shootPoint.position,Quaternion.identity); 
        bullet.SetDamage(Damage);
    }
}
