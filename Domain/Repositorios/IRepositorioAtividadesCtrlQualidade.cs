using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorios
{
    public interface IRepositorioAtividadesCtrlQualidade
    {
        Boolean Adicionar(AtividadeCtrlQualidade a);

        AtividadeCtrlQualidade Recuperar(Int32 id);
    }
}
