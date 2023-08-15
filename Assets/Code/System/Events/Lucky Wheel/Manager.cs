using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Minigames.LuckyWheel
{
    public class Manager : GameManager, IDragHandler, IDropHandler
    {
        [SerializeField] private Spin _mechanic;
        [SerializeField, Range(0, 100)] private float _min = 25, _max = 45;
        [SerializeField] private UnityEvent<Sprite> _onResult;

        private void Start() => Continue = true;
        private void OnEnable() => _mechanic.result += Performance;
        private void OnDisable() => _mechanic.result -= Performance;
        private void OnValidate() => _min = _max < _min ? _max : _min;
        private void Performance(float angle)
        {
            float section = 360f / _generator.List.Length;
            int index = (int)(angle / section); index = index >= _generator.List.Length ? 0 : index;
            StartCoroutine(Result(index));
        }

        private IEnumerator Result(int index)
        {
            yield return _waitForDelay; Continue = true;

            LuckyScriptable lucky = _generator.List[index] as LuckyScriptable;
            _onResult?.Invoke(lucky.icon);
            _onComplete?.Invoke();
            _complete = 0;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!Continue) return;

            //calculate mouse position
            float2 worldPos = (Vector2)eventData.pointerCurrentRaycast.worldPosition;
            float2 position = worldPos - _mechanic.Position;

            //determinate movement
            float v = position.x > 0f ? -eventData.delta.y : eventData.delta.y;
            float h = position.y > 0f ? eventData.delta.x : -eventData.delta.x;
            float speed = math.clamp(h + v, -_mechanic.Speed, _mechanic.Speed);

            //rotate object
            _mechanic.Move = speed;
        }
        public void OnDrop(PointerEventData eventData)
        {
            if (!Continue) return;

            _mechanic.Speed *= UnityEngine.Random.Range(_min, _max);
            Continue = false;
        }
    }
}