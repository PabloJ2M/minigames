using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Minigames
{
    [CreateAssetMenu(fileName = "game list", menuName = "minigames/list", order = 0)]
    public class ItemList : ScriptableObject
    {
        [SerializeField] private Item[] _items;

        public Item this[int value] => _items[value];
        public Item[] Elements => _items;
        public int Length => _items.Length;

        [ContextMenu("Order")] private void Order() => _items = _items.OrderBy(x => x.result).ToArray();

        public void Shuffle()
        {
            int length = _items.Length;
            Random random = new Random();

            for (int n = length - 1; n > 0; n--)
            {
                int r = random.Next(0, n);
                Item t = _items[r];

                _items[r] = _items[n];
                _items[n] = t;
            }
        }
        public bool Contains(int[] list, int value, int repeat = 1, bool debug = false)
        {
            int ammount = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == value) ammount++;
                if (ammount >= repeat)
                {
                    if (debug) Debug.LogWarning($"repeated {value}");
                    return true;
                }
            }
            return false;
        }
    }
}