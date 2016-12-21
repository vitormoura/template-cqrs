using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.Comandos
{
    public class CommandBusPadrao : ICommandBus
    {
        private ConcurrentDictionary<Type, Object> commands;

        public CommandBusPadrao()
        {
            this.commands = new ConcurrentDictionary<Type, Object>();
        }

        public Task Register<T>(ICommandHandler<T> handler)
            where T : ICommand
        {
            if (handler == null)
                throw new ArgumentNullException("handler");

            if(!this.commands.ContainsKey(typeof(T)))
            {
                this.commands.TryAdd(typeof(T), handler);
            }
            else
            {
                this.commands[typeof(T)] = handler;
            }

            return Task.Delay(0);
        }

        public Task<ICommandResult> Send<T>(T cmd) 
            where T : ICommand
        {
            if (cmd == null)
                throw new ArgumentNullException("cmd");

            if (this.commands.ContainsKey(typeof(T)))
            {
                return ((ICommandHandler<T>)this.commands[typeof(T)]).Handle(cmd);
            }
            else
                throw new ArgumentException("Comando não suportado");
        }
    }
}
