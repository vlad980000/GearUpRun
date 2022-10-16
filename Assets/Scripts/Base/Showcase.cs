using UnityEngine;
using DG.Tweening;

public abstract class Showcase : MonoBehaviour
{
    [SerializeField] protected GameObject _goodsPosition;

    public abstract void StartAnimation();
}
