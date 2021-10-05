using senai.SpMedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Interfaces
{
    interface IEspecialidadeRepository
    {
        /// <summary>
        /// Método responsável por listar todas as Especialidades
        /// </summary>
        /// <returns>Uma lista de Especialidades</returns>
        List<Especialidade> ListarTodos();

        /// <summary>
        /// Método responsável por buscar uma Especialidade pelo seu Id
        /// </summary>
        /// <param name="Id">Id da Especialidade buscada</param>
        /// <returns>A Especialidade com o Id buscado</returns>
        Especialidade BuscarPoId(int Id);

        /// <summary>
        /// Método responsável por atualizar uma Especialidade pelo seu Id
        /// </summary>
        /// <param name="Id">Id da Especialidade atualizada</param>
        /// <param name="EspecialidadeAtualizada">Novos valores para a atualização</param>
        void Atualizar(int Id, Especialidade EspecialidadeAtualizada);

        /// <summary>
        /// Método Responsável por cadastrar uma nova Especialidade
        /// </summary>
        /// <param name="EspecialidadeNova">Nova Especialidade a ser cadastrada</param>
        void Cadastrar(Especialidade EspecialidadeNova);

        /// <summary>
        /// Método responsável por deletar uma Especialidade pelo seu Id
        /// </summary>
        /// <param name="Id">Id da Especialidade deletada</param>
        void Deletar(int Id);
    }
}
