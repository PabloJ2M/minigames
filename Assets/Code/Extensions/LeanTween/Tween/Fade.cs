using System;
using UnityEngine;

namespace Effects
{
    public class Fade : Tweening
    {
        [SerializeField] private bool _ignoreTimeScale;
        private float _target;

        protected virtual float _alpha { get; set; }
        protected Action<bool> _onFade;
        protected bool _isVisible;

        public override void Animation(bool forward)
        {
            _target = forward ? 1 : 0;
            if (_alpha == _target) return;

            base.Animation(forward);

            LTDescr tween = LeanTween.value(gameObject, _alpha, _target, _time);
            if (_ignoreTimeScale) tween.setIgnoreTimeScale(true);
            tween.setOnComplete(OnComplete);
            tween.setOnUpdate(OnUpdate);
            tween.setEase(_curve);

            _tweenID = tween.uniqueId;
            _isVisible = forward;
        }

        protected virtual void OnUpdate(float value) => _alpha = value;
        protected virtual void OnComplete()
        {
            _onFade?.Invoke(_isVisible);
            _alpha = _isVisible ? 1 : 0;
            _tweenID = -1;
        }

        public void FadeIn() => Animation(true);
        public void FadeOut() => Animation(false);
    }
}