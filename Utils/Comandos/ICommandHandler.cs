using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.Comandos
{
    /// <summary>
    /// Componente capaz de executar comandos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommandHandler<T>
        where T : ICommand
    {
        /// <summary>
        /// Executa comando do tipo T
        /// </summary>
        /// <param name="command"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task<ICommandResult> Handle(T command);
    }
}
