using UnityEngine;

namespace Minigames.Memory
{
    [CreateAssetMenu(fileName = "memory card", menuName = "minigames/memory")]
    public class CardScriptable : Item
    {
        [Header("Game Details")]
        public Sprite image;
    }
}