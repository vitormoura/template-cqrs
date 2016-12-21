using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.Eventos
{
    /// <summary>
    /// Representa um evento
    /// </summary>
    public interface IEvent
    {
        Guid ID { get; }

        Int32 Versao { get; }

        String Descricao { get; }

        DateTime Ocorrencia { get; }        
    }
}
