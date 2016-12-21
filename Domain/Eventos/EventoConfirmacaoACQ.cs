using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eventos
{
    public class EventoConfirmacaoACQ : EventoAtividadeCtrlQualidade
    {
        public EventoConfirmacaoACQ()
            : base("05C51D59-E98B-4F5C-8516-DF2C868A69F2", "Atividade Ctrl. Qualidade Confirmada")
        {
        }
    }
}
