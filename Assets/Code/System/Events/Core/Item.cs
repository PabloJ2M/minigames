using UnityEngine;

namespace Minigames
{
    public abstract class Item : ScriptableObject
    {
        [Header("Game Result Value")]
        public int result = 1;

        protected virtual void OnValidate() => result = Mathf.Clamp(result, 1, int.MaxValue);
    }
}