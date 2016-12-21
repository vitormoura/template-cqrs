using Domain.Utils.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eventos
{
    public abstract class EventoAtividadeCtrlQualidade : EventoPadrao
    {
        public Int32 IDAtividadeCQ { get; set; }

        public EventoAtividadeCtrlQualidade(String id, String desc)
            : base(id, desc)
        {
        }
    }
}
