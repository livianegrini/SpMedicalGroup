using senai.SpMedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// Método responsável por listar todas as Consultas que um determinado usuário possui
        /// </summary>
        /// <returns>Uma lista de Consultas</returns>
        List<Medico> ListarTodos(int IdUsuario);
    }
}
