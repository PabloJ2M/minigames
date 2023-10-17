using UnityEngine;
using Effects;

public class Loading : Rotate
{
    [SerializeField] private GameObject _container;

    public override void Animation(bool value)
    {
        _container.SetActive(value);
        base.Animation(value);
    }
}