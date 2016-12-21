using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.Eventos
{
    /// <summary>
    /// Componente capaz de atender eventos de um tipo específico
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEventHandler<T>
        where T : IEvent
    {
        /// <summary>
        /// Trata evento do tipo T
        /// </summary>
        /// <param name="evento"></param>
        void Handle(T evento);
    }
}
