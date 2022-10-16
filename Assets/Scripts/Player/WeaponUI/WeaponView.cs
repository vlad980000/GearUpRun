using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _damage;
    [SerializeField] private TMP_Text _level;

    [SerializeField] private Image _icon;
    
    private Weapon _weapon;

    public void Render(Weapon weapon)
    {
        _weapon = weapon;

        _name.text = _weapon.name;
        _damage.text = $"Damage :{_weapon.Damage.ToString()}";
        _level.text = $"Level :{_weapon.Level.ToString()}";
        _icon.sprite = _weapon.Image;
    }
}
