using UnityEngine;

namespace Effects
{
    public abstract class Tweening : MonoBehaviour
    {
        [Header("Animation")]
        [SerializeField] protected AnimationCurve _curve;
        [SerializeField, Range(0, 1)] protected float _time = 1;
        [SerializeField] protected bool _loop = false;

        protected int _tweenID = -1;

        public abstract void Animation(bool forward);
    }
}