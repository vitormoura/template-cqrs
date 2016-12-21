using Domain.Entidades;
using Domain.Eventos;
using Domain.Repositorios;
using Domain.Utils.Comandos;
using Domain.Utils.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Comandos
{
    public class AgendarNovaACQHandler : ICommandHandler<AgendarNovaACQ>
    {
        private IRepositorioAtividadesCtrlQualidade atividades;
        private IEventSource events;

        public AgendarNovaACQHandler(
            IEventSource events, 
            IRepositorioAtividadesCtrlQualidade atividades)
        {
            this.atividades = atividades;
            this.events = events;
        }

        public Task<ICommandResult> Handle(AgendarNovaACQ command)
        {
            AtividadeCtrlQualidade ativ = new AtividadeCtrlQualidade();
            ativ.Agendar(command.Local, command.Periodo);
                        
            this.atividades.Adicionar(ativ);

            //Avisando interessados no evento
            events.Publish(new EventoAgendamentoNovaACQ { IDAtividadeCQ = ativ.ID });

            return Task.FromResult(CommandResultPadrao.Success());
        }
    }
}
