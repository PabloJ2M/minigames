using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Minigames.LuckyWheel
{
    public class Piece : MonoBehaviour, IResult
    {
        [SerializeField] private Image _background, _iconImage;
        [SerializeField] private RectTransform _icon;

        public Sprite Image { set => _iconImage.sprite = value; }
        public int ID { get; set; }

        private void Reset()
        {
            _icon = transform.GetChild(0) as RectTransform;
            _iconImage = _icon.GetComponent<Image>();
            _background = GetComponent<Image>();
        }

        public void Trigger(BaseEventData eventData) { }
        public void Color(Color color) => _background.color = color;
        public void Angle(float value, int additive)
        {
            transform.eulerAngles = new(0f, 0f, -value * additive);
            _icon.localEulerAngles = new(0f, 0f, -value * 0.5f);
            _background.fillAmount = value / 360f;
        }
        public void Distance(float value)
        {
            Vector2 direction = transform.InverseTransformDirection(_icon.up);
            _icon.localPosition = value * direction;
        }
    }
}