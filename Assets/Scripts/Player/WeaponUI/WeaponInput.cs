using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInput : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    [SerializeField] private WeaponView _weaponView;

    [SerializeField] private GameObject _conteiner;

    private void Start()
    {
        for (int i = 0; i < _player.Weapons.Length; i++)
            AddWeapon(_player.Weapons[i]);
    }

    private void AddWeapon(Weapon weapon)
    {
        var view = Instantiate(_weaponView,_conteiner.transform);

        view.Render(weapon);
    }
}
