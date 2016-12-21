using Domain.Entidades;
using Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dados
{
    public class RepositorioAtividadesCtrlQualidade : IRepositorioAtividadesCtrlQualidade
    {
        private Int32 nextID;
        private Dictionary<Int32, AtividadeCtrlQualidade> dados;

        public RepositorioAtividadesCtrlQualidade()
        {
            this.dados = new Dictionary<int, AtividadeCtrlQualidade>();
        }

        public bool Adicionar(Domain.Entidades.AtividadeCtrlQualidade a)
        {
            a.ID = Interlocked.Increment(ref nextID);
            this.dados.Add(a.ID, a);

            return true;
        }

        public AtividadeCtrlQualidade Recuperar(int id)
        {
            if (this.dados.ContainsKey(id))
                return this.dados[id];
            else
                return null;
        }
    }
}
