using UnityEngine;

namespace Effects
{
    public abstract class Tweening : MonoBehaviour
    {
        [Header("Animation")]
        [SerializeField] protected AnimationCurve _curve;
        [SerializeField, Range(0, 1)] protected float _time = 1;
        [SerializeField] protected bool _playOnAwake, _loop;

        protected int _tweenID = -1;

        protected virtual void Awake() { if (_playOnAwake) Animation(false); }
        public virtual void Animation(bool forward) => CancelTween();

        public virtual void CancelTween()
        {
            if (_tweenID == -1) return;
            LeanTween.cancel(_tweenID);
            _tweenID = -1;
        }
    }
}