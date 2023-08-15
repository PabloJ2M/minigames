using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

namespace Minigames.Survey
{
    public class Answer : MonoBehaviour, IResult
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private UnityEvent<bool> _onSwipe, _onResult;
        private GameManager _manager;

        public int ID { get; set; }
        public string Text { set => _text.SetText(value); }

        private void Awake() { _manager = GetComponentInParent<GameManager>(); }

        public void Trigger(BaseEventData eventData)
        {
            if (_manager.Continue) return;

            bool result = _manager.Compare(ID);
            _manager?.onCompare(result);
            _onResult?.Invoke(result);
        }

        public void Show(float delay) => StartCoroutine(Delay(delay, false));
        public void Hide(float delay) => StartCoroutine(Delay(delay, true));
        
        private IEnumerator Delay(float time, bool value)
        {
            if (time == 0) yield break;
            yield return new WaitForSeconds(time);
            _onSwipe.Invoke(value);
        }
    }
}