using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.Eventos
{
    /// <summary>
    /// Implementação de eventsource inproc
    /// </summary>
    public class EventSourcePadrao : IEventSource
    {
        private ConcurrentDictionary<Type, List<Object>> handlers;

        public EventSourcePadrao()
        {
            this.handlers = new ConcurrentDictionary<Type, List<Object>>();
        }
        
        public Task Publish<T>(T evento)
            where T : IEvent
        {
            if (this.handlers.Count > 0)
            {
                var handlers = this.handlers[typeof(T)];

                return Task.Run(() =>
                {
                    foreach (var h in handlers)
                    {
                        ((IEventHandler<T>)h).Handle(evento);
                    }
                });
            }
            else
                return Task.Delay(0);
        }

        public Task Subscribe<T>(IEventHandler<T> handler)
            where T : IEvent
        {
            if (handler == null)
                throw new ArgumentNullException("handler");

            if (!handlers.ContainsKey(typeof(T)))
            {
                this.handlers.TryAdd(typeof(T), new List<Object>());
            }

            this.handlers[typeof(T)].Add(handler);

            return Task.Delay(0);
        }
    }
}
