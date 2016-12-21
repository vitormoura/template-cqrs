using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Periodo
    {
        public DateTime Inicio { get; set; }

        public DateTime Termino { get; set; }

        public Periodo(DateTime i, DateTime t)
        {
            if (i > t)
                throw new ArgumentException("Período inválido");

            this.Inicio = i;
            this.Termino = t;
        }

        public static Periodo MesCorrente() 
        {
            var inicio = new DateTime( DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1);
            var termino = inicio.AddMonths(1).AddDays(-1);

            return new Periodo(inicio, termino);
        }

        public static Periodo Hoje()
        {
            var inicio  = DateTime.Now.Date;
            var termino = inicio.AddDays(1).AddSeconds(-1);

            return new Periodo(inicio, termino);
        }
    }
}
