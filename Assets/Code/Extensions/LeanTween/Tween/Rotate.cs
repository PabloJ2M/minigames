using Unity.Mathematics;
using UnityEngine;

namespace Effects
{
    public class Rotate : Tweening
    {
        [Header("Controller")]
        [SerializeField] private Transform _objetc;
        [SerializeField] private float3 _axis;
        [SerializeField] private float _degres;

        public override void Animation(bool forward)
        {
            base.Animation(forward);
            if (!forward) return;

            LTDescr tween = LeanTween.rotateAround(_objetc.gameObject, _axis, -_degres, _time);
            if (_curve != null) tween.setEase(_curve);
            if (_loop) tween.setRepeat(-1);
            _tweenID = tween.uniqueId;
        }
    }
}