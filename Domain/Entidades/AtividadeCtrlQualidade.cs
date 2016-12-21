using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class AtividadeCtrlQualidade
    {
        public enum Estados
        {
            Indefinido,
            Agendada,
            Confirmada,
            EmElaboracaoRelatorio,
            AgElaboracaoPlanoAcao,
            EmElaboracaoPlanoAcao,
            AgRevisaoRCQ,
            EmRevisaoRCQ,
            EmAcompanhamento
        }

        public Int32 ID { get; set; }

        public Localidade Local { get; set; }

        public Periodo PeriodoRealizacao { get; set; }

        public Estados Estado { get; set; }

        public Auditor Lider { get; set; }

        public IEnumerable<Auditor> Equipe { get; set; }
        
        public AtividadeCtrlQualidade()
        {
            this.Estado = Estados.Indefinido;
        }

        public void Agendar(Localidade l, Periodo p)
        {
            if (this.Estado != Estados.Indefinido)
                throw new ArgumentException("Estado inválido");

            this.Local = l;
            this.PeriodoRealizacao = p;
            this.Estado = Estados.Agendada;
        }

        public void Confirmar(Auditor lider, IEnumerable<Auditor> outrosMembrosEquipe)
        {
            this.Lider = lider;
            this.Estado = Estados.Confirmada;
        }
    }
}
