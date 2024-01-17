using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

namespace Effects
{
    public enum Direction { Horizontal, Vertical }

    public class Swipe : Tweening
    {
        [Header("Effect")]
        [SerializeField] private RectTransform _rect;
        [SerializeField] private bool _invertDirection;
        [SerializeField] private Direction _orientation;
        [SerializeField] private UnityEvent<bool> _onEnable;

        private Vector2 _position, _target;

        private void Start() => _position = _rect.localPosition;

        protected Vector2 CalculateDirection()
        {
            bool orient = _orientation == Direction.Horizontal;
            float3 direction = orient ? mathf.right : mathf.up;
            return _invertDirection ? -direction.xy : direction.xy;
        }
        protected float CalculateSize()
        {
            bool orient = _orientation == Direction.Horizontal;
            return orient ? _rect.sizeDelta.x : _rect.sizeDelta.y;
        }

        public void SwipeIn() => Animation(true);
        public void SwipeOut() => Animation(false);
        public override void Animation(bool value)
        {
            CancelTween();
            _onEnable.Invoke(value);
            _target = CalculateSize() * CalculateDirection() + _position;

            LTDescr tween = LeanTween.moveLocal(_rect.gameObject, value ? _target : _position, _time);
            tween.setOnComplete(CancelTween);
            tween.setEase(_curve);

            _tweenID = tween.uniqueId;
        }
    }
}