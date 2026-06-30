namespace task21.Interfaces
{
    public interface IEventBus
    {
        void Publish<T>(T eventArgs);

        void Subscribe<T>(Action<T> handler);
    }
}
