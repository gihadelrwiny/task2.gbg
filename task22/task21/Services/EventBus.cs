using System.Collections.Concurrent;
using task21.Interfaces;

namespace task21.Services
{
    public class EventBus : IEventBus
    {
        private readonly ConcurrentDictionary<Type, List<Delegate>> _handlers
            = new();

        public void Subscribe<T>(Action<T> handler)
        {
            var handlers = _handlers.GetOrAdd(typeof(T), _ => new List<Delegate>());

            handlers.Add(handler);
        }

        public void Publish<T>(T eventArgs)
        {
            if (_handlers.TryGetValue(typeof(T), out var handlers))
            {
                foreach (var handler in handlers)
                {
                    ((Action<T>)handler)(eventArgs);
                }
            }
        }
    }
}
