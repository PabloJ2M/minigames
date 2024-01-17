using UnityEngine;

namespace Effects
{
    public class SwipeRepeating : Swipe
    {
        [SerializeField] private RectTransform _object;
        [SerializeField, Range(1, 5)] private int _steps = 1;

        private Vector3 _origin, _displacement;
        private int _current;

        protected override async void Awake()
        {
            await System.Threading.Tasks.Task.Delay(500);

            _displacement = CalculateSize() * (Vector3)CalculateDirection();
            _object.localPosition -= _displacement;
            _origin = _object.localPosition;

            base.Awake();
        }

        public override void Animation(bool value)
        {
            _current++;
            Vector3 target = _current * _displacement;

            LTDescr tween = LeanTween.moveLocal(_object.gameObject, _origin + target, _time);
            if (_loop) tween.setLoopPingPong(-1);
            tween.setOnComplete(onComplete);
            tween.setEase(_curve);

            void onComplete()
            {
                if (_current < _steps) return;
                _object.localPosition = _origin;
                _current = 0;
            }
        }
    }
}