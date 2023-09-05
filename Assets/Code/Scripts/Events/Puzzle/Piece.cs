using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Minigames.Puzzle
{
    public class Piece : MonoBehaviour
    {
        [SerializeField] private RectTransform _self;
        [SerializeField] private AnimationCurve _curve;

        public int ID;
        private Manager _manager;
        private Transform _container;

        private void Awake() { _manager = GetComponentInParent<Manager>(); _container = _self.parent.parent; }

        public void Pick(BaseEventData eventData)
        {
            LeanTween.cancel(gameObject);
            _self.SetParent(_container);
            _self.SetAsLastSibling();
            _manager.IsDraging(true);
        }
        public void Drag(BaseEventData eventData)
        {
            Vector2 screen = eventData.currentInputModule.input.mousePosition;
            float3 global = _manager.WorldPoint(screen);
            _self.position = global;
        }
        public void Drop(BaseEventData eventData)
        {
            float3 target = _manager.DetectPlaceTarget(ID, eventData.currentInputModule.input.mousePosition);
            _manager.IsDraging(false);

            if (!mathf.Compare(target, mathf.none))
                LeanTween.move(gameObject, target, 0.5f).setEase(_curve);
        }
    }
}