using Domain.Eventos;
using Domain.Utils.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class ServicoNotificacao 
        : IEventHandler<Eventos.EventoAgendamentoNovaACQ>,
        IEventHandler<Eventos.EventoConfirmacaoACQ>
    {
        private List<IEvent> historico;

        public IEnumerable<IEvent> Historico
        {
            get { return this.historico; }
        }

        public ServicoNotificacao()
        {
            this.historico = new List<IEvent>();
        }

        public void Handle(EventoAgendamentoNovaACQ evento)
        {
            this.historico.Add(evento);
        }

        public void Handle(EventoConfirmacaoACQ evento)
        {
            throw new NotImplementedException();
        }
    }
}
