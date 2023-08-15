using System;
using UnityEngine;
using UnityEngine.Events;

namespace Minigames
{
    [RequireComponent(typeof(IBuilder))]
    public abstract class GameManager : MonoBehaviour
    {
        [SerializeField, Range(0, 5)] private float _delay = 1;
        [SerializeField] protected UnityEvent _onComplete;

        public Action<bool> onCompare = null;
        public bool Continue { get; protected set; }

        protected int _complete;
        protected IBuilder _generator;
        protected WaitForSeconds _waitForDelay;
        
        public virtual bool Compare(int value) => true;
        protected virtual void Awake()
        {
            _generator = GetComponent<IBuilder>();
            _waitForDelay = new WaitForSeconds(_delay);
        }
    }
}