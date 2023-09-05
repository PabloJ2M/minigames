using UnityEngine;
using UnityEngine.UI;

namespace Minigames.Memory
{
    public class GridLayoutController : MonoBehaviour
    {
        [SerializeField, Range(0, 1)] private float _spacing = 0.5f;
        [SerializeField] private TextAnchor _alignment = TextAnchor.MiddleCenter;

        private HorizontalOrVerticalLayoutGroup[] _layouts = null; 

        [ContextMenu("SetUp")] private void SetUp() =>
            _layouts = GetComponentsInChildren<HorizontalOrVerticalLayoutGroup>();

        private void Reset() => SetUp();
        private void OnValidate()
        {
            if (_layouts == null) return;
            for (int i = 0; i < _layouts.Length; i++)
            {
                _layouts[i].spacing = _spacing * 100;
                _layouts[i].childAlignment = _alignment;
            }
        }
    }
}