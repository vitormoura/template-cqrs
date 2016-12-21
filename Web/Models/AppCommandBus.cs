using Domain.Utils.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Web.Models
{
    /// <summary>
    /// CommandBus que utiliza o resolver de dependências do ASP.NET MVC 
    /// para localizar componentes com capacidade de responder comandos
    /// </summary>
    public class AppCommandBus : ICommandBus
    {
        private IDependencyResolver serviceLocator;

        public AppCommandBus()
            : this(DependencyResolver.Current)
        {
        }

        public AppCommandBus(IDependencyResolver serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public Task<ICommandResult> Send<T>(T cmd) 
            where T : ICommand
        {
            var handler = this.serviceLocator.GetService(typeof(ICommandHandler<T>));

            if (handler == null)
                throw new ArgumentException("Comando não suportado: " + typeof(T).Name);

            return ((ICommandHandler<T>)handler).Handle(cmd);
        }

        public Task Register<T>(ICommandHandler<T> handler) 
            where T : ICommand
        {
            return Task.Delay(0);
        }
    }
}