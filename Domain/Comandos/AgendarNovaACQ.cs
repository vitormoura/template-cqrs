using Domain.Entidades;
using Domain.Utils.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Comandos
{
    public class AgendarNovaACQ : ICommand
    {
        public Localidade Local { get; set; }

        public Periodo Periodo { get; set; }
    }
}
