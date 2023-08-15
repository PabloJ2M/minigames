using UnityEngine;

namespace Minigames
{
    public class GameGenerator : MonoBehaviour, IBuilder
    {
        [SerializeField] protected ItemList _list;
        [SerializeField] protected bool _random = true;
        protected IResult[] _items;

        public ItemList List => _list;
        public virtual int Length => 0;
        public virtual float Delay => 0;

        protected virtual void Awake()
        {
            _items = GetComponentsInChildren<IResult>();
            if (_random) _list?.Shuffle();
        }
    }
}