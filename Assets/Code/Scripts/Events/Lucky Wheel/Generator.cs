using UnityEngine;

namespace Minigames.LuckyWheel
{
    public class Generator : GameGenerator
    {
        [Header("Configuration")]
        [SerializeField, Range(0, 5)] private float _distance;
        [SerializeField] private Color[] _colors = new Color[2];

        [SerializeField] private Piece[] _icons;

        [ContextMenu("Setup Icons")]
        private void Start()
        {
            if (_list == null) { print("<color=red>empty list</color>"); return; }
            if (_list.Length < _icons.Length) { print("<color=red>not enough items</color>"); return; }

            for (int i = 0; i < _icons.Length; i++)
            {
                LuckyScriptable scriptable = _list[i] as LuckyScriptable;
                _icons[i].Image = scriptable.icon;
                _icons[i].ID = scriptable.result;
            }
        }
        private void OnValidate()
        {
            if (_icons == null) return;

            int color = 0;
            int length = _icons.Length;
            float angle = 360f / length;

            for (int i = 0; i < length; i++)
            {
                _icons[i].Angle(angle, i);
                _icons[i].Color(_colors[color]);
                _icons[i].Distance(_distance * 100f);
                color = color < _colors.Length - 1 ? color += 1 : 0;
            }
        }
    }
}