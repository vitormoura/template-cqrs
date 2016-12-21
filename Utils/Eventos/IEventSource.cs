using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.Eventos
{
    /// <summary>
    /// Representa fonte de eventos da aplicação
    /// </summary>
    public interface IEventSource
    {
        /// <summary>
        /// Registra a ocorrência de um novo evento
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="evento"></param>
        Task Publish<T>(T evento)
            where T : IEvent;

        /// <summary>
        /// Registra interesse em ocorrências de eventos identificados pelo ID informado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler"></param>
        Task Subscribe<T>(IEventHandler<T> handler)
            where T : IEvent;
    }
}
