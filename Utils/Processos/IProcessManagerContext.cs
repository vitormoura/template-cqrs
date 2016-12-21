using Domain.Utils.Comandos;
using Domain.Utils.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.Processos
{
    /// <summary>
    /// Contexto de execução de componentes do tipo Process Manager
    /// </summary>
    public interface IProcessManagerContext
    {
        /// <summary>
        /// Usuário responsável
        /// </summary>
        IPrincipal User { get; }

        /// <summary>
        /// Acesso a origem de eventos
        /// </summary>
        IEventSource Events { get; }
        
        /// <summary>
        /// Acesso ao commandbus
        /// </summary>
        ICommandBus CommandBus { get; }
    }
}
