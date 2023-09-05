using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

namespace Minigames.LuckyWheel
{
    public class Pointer : MonoBehaviour
    {
        [SerializeField] private RectTransform _wheel;
        [SerializeField] private RectTransform _selector;

        [SerializeField, Range(0, 180)] private float _angle = 15f;
        [SerializeField, Range(0, 0.3f)] private float _delay = 0.1f;

        [SerializeField] private AudioClip _clip;
        [SerializeField] private UnityEvent<AudioClip> _onClip;

        private float _currentDelay, _force;
        private quaternion _previusRotation;

        private void Start() => _previusRotation = _wheel.rotation;
        private void Update()
        {
            //torque
            _force = math.lerp(_force, 0f, 10 * Time.deltaTime);
            _selector.localRotation = quaternion.Euler(0f, 0f, _force);

            //delay
            _currentDelay = _currentDelay > 0f ? _currentDelay -= Time.deltaTime : 0f;
            if (_currentDelay > 0f) return;

            //get wheel angle
            quaternion diference = _wheel.rotation * math.conjugate(_previusRotation);
            float angle = math.degrees(math.atan2(diference.value.z, diference.value.w) * 2f);

            if (math.abs(angle) < _angle) return;

            _force += 0.5f * (angle > 0f ? -1f : 1f);
            _previusRotation = _wheel.rotation;
            _currentDelay = _delay;

            _onClip?.Invoke(_clip);
        }
    }
}