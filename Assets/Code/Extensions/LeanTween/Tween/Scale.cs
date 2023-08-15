using UnityEngine;

namespace Effects
{
    public class Scale : Tweening
    {
        [Header("Effects")]
        [SerializeField, Range(0, 2)] private float _factor;

        public override void Animation(bool forward)
        {
            LTDescr tween = LeanTween.scale(gameObject, _factor * Vector3.one, _time);
            if (_loop) tween.setLoopPingPong(-1);
            tween.setEase(_curve);
        }
    }
}