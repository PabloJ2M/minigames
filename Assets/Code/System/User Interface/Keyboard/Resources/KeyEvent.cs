using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    public class KeyEvent : MonoBehaviour, IKey
    {
        [SerializeField] private UnityEvent _onSelect;

        public void OnSelect(BaseEventData data)
        {
            _onSelect.Invoke();
        }
    }
}