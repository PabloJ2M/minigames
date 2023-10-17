using UnityEngine;

namespace Effects
{
    public class Scale : Tweening
    {
        [Header("Effects")]
        [SerializeField, Range(0.8f, 1.2f)] private float _factor = 1;

        public override void Animation(bool forward)
        {
            LTDescr tween = LeanTween.scale(gameObject, _factor * mathf.one, _time);
            if (_loop) tween.setLoopPingPong(-1);
            tween.setEase(_curve);
        }
        public override void CancelTween()
        {
            base.CancelTween();
            transform.localScale = mathf.one;
        }
    }
}