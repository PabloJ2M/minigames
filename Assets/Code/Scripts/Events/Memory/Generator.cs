using UnityEngine;

namespace Minigames.Memory
{
    public class Generator : GameGenerator
    {
        [SerializeField, Range(1, 5)] private int _repeat = 1;
        [SerializeField] private bool _debug = false;

        public override int Length => _repeat;

        protected override void Awake()
        {
            base.Awake();

            //determinate random size
            int size = Mathf.CeilToInt(_items.Length / (float)_repeat);
            bool notEnough = _list.Length < size;

            //break login
            if (notEnough && _debug) print("<color=red>not enough cards in memory list</color>");
            if (notEnough) return;

            //setup cards with random values
            int[] values = new int[_items.Length];

            for (int i = 0; i < _items.Length; i++)
            {
                //choose random number
                int r = Random.Range(0, Mathf.Clamp(size, 1, _items.Length));
                int v = _list[r].result;

                if (_list.Contains(values, v, _repeat, _debug)) { i--; continue; }

                //setup random card
                CardScriptable card = _list[r] as CardScriptable;
                Card item = _items[i] as Card;

                if (_debug) print($"<color=green>item added to table { card.result }</color>");
                item.ID = values[i] = card.result;
                item.Image = card.image;
            }
        }
    }
}