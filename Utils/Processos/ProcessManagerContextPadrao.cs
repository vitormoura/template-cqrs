using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.Processos
{
    public class ProcessManagerContextPadrao : IProcessManagerContext
    {
        public System.Security.Principal.IPrincipal User
        {
            get;
            set;
        }

        public Eventos.IEventSource Events
        {
            get;
            set;
        }

        public Comandos.ICommandBus CommandBus
        {
            get;
            set;
        }
    }
}
