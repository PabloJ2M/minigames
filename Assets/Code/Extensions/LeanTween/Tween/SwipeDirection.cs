using Unity.Mathematics;
using UnityEngine;

namespace Effects
{
    [ExecuteAlways]
    public class SwipeDirection : Tweening
    {
        [Header("Effect")]
        [SerializeField, Range(1, 5)] private int _steps = 1;
        [SerializeField] private Vector3 _direction;

        private Vector3 _origin;
        private int _current;

        protected override void Awake() { _origin = transform.position; base.Awake(); }

        public override void Animation(bool forward)
        {
            Vector3 target = math.abs(_origin.x) * _direction + transform.position;
            _current++;

            LTDescr tween = LeanTween.move(gameObject, target, _time);
            if (_loop) tween.setLoopPingPong(-1);
            tween.setOnComplete(onComplete);
            tween.setEase(_curve);

            void onComplete()
            {
                if (_current < _steps) return;
                transform.position = _origin;
                _current = 0;
            }
        }
    }
}