namespace Minigames
{
    public interface IBuilder
    {
        public ItemList List { get; }
        public IResult[] Results { get; }

        public int Length { get; }
        public float Delay { get; }
    }
}