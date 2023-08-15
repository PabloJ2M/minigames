using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Minigames.Memory
{
    public class Card : MonoBehaviour, IResult
    {
        [SerializeField] private Image _image;
        [SerializeField] private UnityEvent<bool> _onActive;

        private GameManager _manager;
        private Sprite _normal, _hide;
        private bool _enabled;

        public int ID { get; set; }
        public Sprite Image { set => _hide = value; }
        public float Swipe { set => _image.sprite = value < 0.5f ? _normal : _hide; }

        private void Awake() => _manager = GetComponentInParent<GameManager>();
        private void Start() => _normal = _image.sprite;

        public void Trigger(BaseEventData eventData)
        {
            if (_enabled) return;
            if (!_manager.Compare(ID)) return;

            _manager.onCompare += Performe;
            _onActive?.Invoke(true);
            _enabled = true;
        }
        private void Performe(bool result)
        {
            _manager.onCompare -= Performe;

            if (result) return;
            _onActive?.Invoke(false);
            _enabled = false;
        }
    }
}