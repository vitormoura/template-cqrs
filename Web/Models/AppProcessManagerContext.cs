using Domain.Utils.Comandos;
using Domain.Utils.Eventos;
using Domain.Utils.Processos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Web.Models
{
    /// <summary>
    /// ProcessManagerContext que utiliza o resolver de dependências do ASP.NET MVC 
    /// para localizar commandbus e eventsource padrão
    /// </summary>
    public class AppProcessManagerContext : IProcessManagerContext
    {
        public IPrincipal User
        {
            get { return HttpContext.Current.User; }
        }

        public IEventSource Events
        {
            get;
            private set;
        }

        public ICommandBus CommandBus
        {
            get;
            private set;
        }

        public AppProcessManagerContext(ICommandBus commandBus, IEventSource eventSource)
        {
            this.CommandBus = commandBus;
            this.Events = eventSource;
        }
    }
}