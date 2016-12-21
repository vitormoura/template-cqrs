using Domain.Comandos;
using Domain.Entidades;
using Domain.Eventos;
using Domain.Repositorios;
using Domain.Utils.Comandos;
using Domain.Utils.Eventos;
using Domain.Utils.Processos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Processos
{
    public class GestorProcessosElaboracaoRelatorioACQ : ProcessManager,
        IEventHandler<EventoAgendamentoNovaACQ>
    {
        private IRepositorioAtividadesCtrlQualidade atividades;
                
        public GestorProcessosElaboracaoRelatorioACQ(
            IProcessManagerContext context,
            IRepositorioAtividadesCtrlQualidade atividades )
            : base(context)
        {
            this.atividades = atividades;

            this.Subscribes<EventoAgendamentoNovaACQ>();
        }
                
        public void Handle(EventoAgendamentoNovaACQ evento)
        {
            Console.WriteLine("OK");
        }
    }
}
