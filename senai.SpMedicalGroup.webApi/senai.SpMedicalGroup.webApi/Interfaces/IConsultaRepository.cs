using senai.SpMedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Interfaces
{
    interface IConsultaRepository
    {
        /// <summary>
        /// Método responsável por listar todas as Consultas
        /// </summary>
        /// <returns>Uma lista de Consultas</returns>
        List<Consultum> ListarTodos();

        /// <summary>
        /// Método responsável por buscar um Consulta pelo seu Id
        /// </summary>
        /// <param name="Id">Id da Consulta buscada</param>
        /// <returns>A Consulta com o Id buscado</returns>
        Consultum BuscarPoId(int Id);

        /// <summary>
        /// Método responsável por deletar uma Consulta pelo seu Id
        /// </summary>
        /// <param name="Id">Id da Consulta deletada</param>
        void Deletar(int Id);

        /// <summary>
        /// Método responsável por atualizar uma Consulta pelo seu Id
        /// </summary>
        /// <param name="Id">Id da Consulta atualizada</param>
        /// <param name="ConsultaAtualizada">Novos valores para a atualização</param>
        void Atualizar(int Id, Consultum ConsultaAtualizada);

        /// <summary>
        /// Método Responsável por cadastrar uma nova Consulta
        /// </summary>
        /// <param name="ConsultaNova">Nova Clinica a ser cadastrada</param>
        void Cadastrar(Consultum ConsultaNova);
    }
}
