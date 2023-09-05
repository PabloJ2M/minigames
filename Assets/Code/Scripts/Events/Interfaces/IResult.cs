using UnityEngine.EventSystems;

namespace Minigames
{
    public interface IResult
    {
        public int ID { get; set; }

        public void Trigger(BaseEventData eventData);
    }
}