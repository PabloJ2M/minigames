using UnityEngine;
using UnityEngine.Events;

namespace Effects
{
    public class ResultColor : Tweening
    {
        [Header("Effects")]
        [SerializeField] private Color _color;
        [SerializeField] private bool _trigger;
        [SerializeField] private UnityEvent<Color> _onValueChange;

        public override void Animation(bool forward)
        {
            if (forward != _trigger) return;

            LTDescr tween = LeanTween.value(gameObject, 0, 1, _time);
            tween.setOnUpdate(onUpdate);
            tween.setEase(_curve);

            void onUpdate(float value) => _onValueChange.Invoke(Color.Lerp(Color.white, _color, value));
        }
    }
}