using Domain.Utils.Comandos;
using Domain.Utils.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.Processos
{
    public abstract class ProcessManager
    {
        protected IProcessManagerContext Context { get; set; }

        public ProcessManager(IProcessManagerContext ctx)
        {
            this.Context = ctx;
        }
        
        /// <summary>
        /// Configura que este process manager junto ao commandbus padrão para executar comandos do tipo T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected Task Handles<T>()
            where T : ICommand
        {
            var handler = this as ICommandHandler<T>;

            if (handler == null)
                throw new ArgumentException("Este ProcessManager não suporta executar comandos do tipo " + typeof(T).Name); 

            return this.Context.CommandBus.Register<T>(handler);
        }

        /// <summary>
        /// Configura este process manager para atender eventos de domínio do tipo T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected Task Subscribes<T>()
            where T : IEvent
        {
            var handler = this as IEventHandler<T>;

            if (handler == null)
                throw new ArgumentException("Este ProcessManager não suporta observar eventos do tipo " + typeof(T).Name ); 

            return this.Context.Events.Subscribe<T>(handler);
        }
    }
}
