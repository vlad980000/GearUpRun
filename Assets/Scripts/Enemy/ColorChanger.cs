using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color _targetColor;

    [SerializeField] private float _timeToChangeColor;

    private SkinnedMeshRenderer _renderer;

    private Color _baseColor;

    private Sequence _sequence;

    private void Start()
    {
        _renderer = GetComponent<SkinnedMeshRenderer>();
        _baseColor = _renderer.material.color;
    }

    public void ChangeColor()
    {
         _renderer.material.DOColor(_targetColor,_timeToChangeColor);
    }

    public void LoopChangeColor()
    {
        _sequence = DOTween.Sequence();

        _sequence.Append(_renderer.material.DOColor(_targetColor,_timeToChangeColor));
        _sequence.Append(_renderer.material.DOColor(_baseColor,_timeToChangeColor));

        _sequence.SetLoops(1, LoopType.Yoyo);
    }
}
