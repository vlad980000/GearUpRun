using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyInput : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyInput;
    [SerializeField] private Player _player;

    private void Start()
    {
        _moneyInput.text = _player.Money.ToString();
    }

    private void OnEnable()
    {
        _player.MoneyIsChanged += OnValueChanged;
    }
    private void OnDisable()
    {
        _player.MoneyIsChanged -= OnValueChanged;
    }

    private void OnValueChanged(int money)
    {
        _moneyInput.text = money.ToString();
    }
}
