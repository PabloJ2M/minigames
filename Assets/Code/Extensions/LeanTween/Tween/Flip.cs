using UnityEngine;
using UnityEngine.Events;

namespace Effects
{
    public class Flip : Tweening
    {
        [Header("Effect")]
        [SerializeField] private Vector3 _axis;
        [SerializeField, Range(0, 180)] private float _angle;

        [SerializeField] private UnityEvent<float> _onValueChange;

        public override void Animation(bool forward)
        {
            Vector3 direction = (forward ? _angle : 0) * _axis;

            LeanTween.rotate(gameObject, direction, _time).setEase(_curve);
            LeanTween.value(gameObject, 0, 1, _time).setEase(_curve).setOnUpdate(onUpdate);

            void onUpdate(float value) => _onValueChange?.Invoke(forward ? value : 1 - value);
        }
    }
}