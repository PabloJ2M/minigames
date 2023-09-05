using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Minigames.Puzzle
{
    public class Manager : GameManager
    {
        [SerializeField] private UnityEvent<bool> _onDragging;

        private GraphicRaycaster _raycaster;
        private EventSystem _eventSystem;
        private Camera _camera;

        private void Start()
        {
            _raycaster = GetComponentInParent<GraphicRaycaster>();
            _eventSystem = EventSystem.current;
            _camera = Camera.main;
            IsDraging(false);
        }
        private void CompareGrid()
        {
            foreach (var item in _generator.Results) { if (!(item as Place).IsComplete) return; }
            _onComplete.Invoke();
        }

        public void IsDraging(bool value) => _onDragging.Invoke(value);
        public float3 WorldPoint(Vector2 input) => _camera.ScreenToWorldPoint(input);
        public float3 DetectPlaceTarget(int id, float2 input)
        {
            PointerEventData data = new PointerEventData(_eventSystem);
            data.position = input;

            float3 position = mathf.none;
            List<RaycastResult> results = new();
            _raycaster?.Raycast(data, results);

            foreach (RaycastResult result in results)
            {
                Place target;
                if (result.gameObject.TryGetComponent(out target)) { target?.Compare(id); position = target.Position; break; }
            }

            CompareGrid();
            return position;
        }
    }
}