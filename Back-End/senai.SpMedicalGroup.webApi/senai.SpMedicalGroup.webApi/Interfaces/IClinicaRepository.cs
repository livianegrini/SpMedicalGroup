using senai.SpMedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Interfaces
{
    interface IClinicaRepository
    {
        /// <summary>
        /// Método responsável por listar todas as Clinicas
        /// </summary>
        /// <returns>Uma lista de Clinicas</returns>
        List<Clinica> ListarTodos();

        /// <summary>
        /// Método responsável por buscar um Clinica pelo seu Id
        /// </summary>
        /// <param name="Id">Id da Clinica buscada</param>
        /// <returns>A Clinica com o Id buscado</returns>
        Clinica BuscarPoId(int Id);

        /// <summary>
        /// Método responsável por atualizar uma Clinica pelo seu Id
        /// </summary>
        /// <param name="Id">Id da Clinica atualizada</param>
        /// <param name="ClinicaAtualizada">Novos valores para a atualização</param>
        void Atualizar(int Id, Clinica ClinicaAtualizada);

        /// <summary>
        /// Método Responsável por cadastrar uma nova Clinica
        /// </summary>
        /// <param name="ClinicaNova">Nova Clinica a ser cadastrada</param>
        void Cadastrar(Clinica ClinicaNova);

        /// <summary>
        /// Método responsável por deletar uma Clinica pelo seu Id
        /// </summary>
        /// <param name="Id">Id da Clinica deletada</param>
        void Deletar(int Id);
    }
}
