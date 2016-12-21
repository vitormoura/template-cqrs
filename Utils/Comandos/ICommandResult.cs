using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.Comandos
{
    /// <summary>
    /// Representa o resultado da execução de um comando
    /// </summary>
    public interface ICommandResult
    {
        /// <summary>
        /// Determina se o resultado é do tipo sucesso
        /// </summary>
        Boolean OK { get; }

        /// <summary>
        /// Lista de erros encontrados durante a execução do comando
        /// </summary>
        IEnumerable<String> Errors { get; }
    }
}
