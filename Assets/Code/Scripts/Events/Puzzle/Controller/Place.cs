using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Minigames.Puzzle
{
    public class Place : MonoBehaviour, IResult
    {
        [SerializeField] private RectTransform _self;

        public int ID { get; set; }
        public bool IsComplete { get; private set; }
        public float3 Position => _self.position;

        public void Compare(int id) { IsComplete = id == ID; if (IsComplete) print("match"); }
        public void Trigger(BaseEventData eventData) { }
    }
}