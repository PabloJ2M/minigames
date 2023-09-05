using Unity.Mathematics;
using UnityEngine;

namespace Minigames.LuckyWheel
{
    public class Spin : MonoBehaviour
    {
        [SerializeField] private RectTransform _self;
        [SerializeField] private AnimationCurve _curve;
        [SerializeField, Range(0, 5)] private float _speed;
        [SerializeField, Range(0, 1)] private float _strengh;

        public float2 Position => (Vector2)_self.position;
        public float Speed { get => _speed; set => _current = _max = value; }
        public float Move { set => _self.Rotate(Vector3.back, value); }

        public System.Action<float> result;
        private float _current, _max;

        private void FixedUpdate()
        {
            if (_current == 0) return;

            //spin effect
            float time = _curve.Evaluate(_current / _max);
            float speed = math.lerp(0f, _max, time);
            Move = speed * 0.5f;

            //desacelerate
            _current = Mathf.MoveTowards(_current, 0f, _strengh);
            
            //complete statement
            if (_current != 0) return;
            result?.Invoke(_self.eulerAngles.z);
        }
    }
}