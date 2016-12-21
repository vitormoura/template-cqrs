using Domain.Utils.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Web.Models
{
    /// <summary>
    /// EventSource que utiliza o resolver de dependências do ASP.NET MVC 
    /// para localizar componentes com capacidade de responder comandos
    /// </summary>
    public class AppEventSource : IEventSource
    {
        private IDependencyResolver serviceLocator;

        public AppEventSource()
            : this(DependencyResolver.Current)
        {
        }

        public AppEventSource(IDependencyResolver serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public Task Publish<T>(T evento) 
            where T : IEvent
        {
            var handlers = this.serviceLocator.GetServices(typeof(IEventHandler<T>));

            if (handlers != null)
            {
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
            return Task.Delay(0);
        }
    }
}