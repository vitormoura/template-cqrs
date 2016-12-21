using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.Eventos
{
    public class EventoPadrao : IEvent
    {
        public Guid ID
        {
            get;
            private set;
        }

        public int Versao
        {
            get;
            protected set;
        }

        public string Descricao
        {
            get;
            private set;
        }

        public DateTime Ocorrencia { get; protected set; }

        public EventoPadrao(String id, String desc)
        {
            this.ID = Guid.Parse(id);
            this.Descricao = desc;
            this.Ocorrencia = DateTime.Now;
        }
    }
}
