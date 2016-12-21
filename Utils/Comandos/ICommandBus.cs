using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.Comandos
{
    /// <summary>
    /// Componente capaz de localizar e preparar outros componentes que executarão comandos
    /// </summary>
    public interface ICommandBus
    {
        /// <summary>
        /// Localiza command handler para executar comando do tipo T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<ICommandResult> Send<T>(T cmd) where T : ICommand;

        /// <summary>
        /// Registra um command handler para o tipo de comando identificado por T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler"></param>
        /// <returns></returns>
        Task Register<T>(ICommandHandler<T> handler)
            where T : ICommand;
    }
}
