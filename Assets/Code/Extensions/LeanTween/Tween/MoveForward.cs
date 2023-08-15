using UnityEngine;

namespace Effects
{
    [ExecuteAlways]
    public class MoveForward : Tweening
    {
        [Header("Effect")]
        [SerializeField] private Vector3 _direction;
        [SerializeField] private float _distance;
        private Vector3 _origin, _current;

        private void Awake() => _current = _origin = transform.position;
        private void OnDrawGizmos() => Gizmos.DrawLine(_current, _current + _distance * _direction);

        public void ResetPosition() => transform.position = _origin;
        public override void Animation(bool forward)
        {
            Vector3 target = transform.position + _distance * _direction;

            LTDescr tween = LeanTween.move(gameObject, target, _time);
            if (_loop) tween.setLoopPingPong(-1);
            tween.setOnComplete(onComplete);
            tween.setEase(_curve);

            void onComplete()
            {
                if (forward) transform.position = _origin;

                //update gizmos
                _current = transform.position;
            }
        }
    }
}