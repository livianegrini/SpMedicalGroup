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
        /// Método responsável por listar todos os Medicos
        /// </summary>
        /// <returns>Uma lista de Medicos</returns>
        List<Medico> ListarTodos();

        /// <summary>
        /// Método responsável por buscar um Medico pelo seu Id
        /// </summary>
        /// <param name="Id">Id do Medicos buscado</param>
        /// <returns>Medico com o Id buscado</returns>
        Medico BuscarPoId(int Id);

        /// <summary>
        /// Método responsável por atualizar um Medico pelo seu Id
        /// </summary>
        /// <param name="Id">Id do Medico atualizado</param>
        /// <param name="MedicoAtualizado">Novos valores para a atualização</param>
        void Atualizar(int Id, Medico MedicoAtualizado);

        /// <summary>
        /// Método Responsável por cadastrar um novo Medico
        /// </summary>
        /// <param name="MedicoNovo">Novo Medico a ser cadastrado</param>
        void Cadastrar(Medico MedicoNovo);

        /// <summary>
        /// Método responsável por deletar um Medico pelo seu Id
        /// </summary>
        /// <param name="Id">Id do Medico deletado</param>
        void Deletar(int Id);
    }
}
