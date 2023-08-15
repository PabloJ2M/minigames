namespace Minigames
{
    public interface IBuilder
    {
        public ItemList List { get; }

        public int Length { get; }
        public float Delay { get; }
    }
}