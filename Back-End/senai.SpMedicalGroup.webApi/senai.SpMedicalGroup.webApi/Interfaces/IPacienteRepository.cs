using senai.SpMedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Interfaces
{
    interface IPacienteRepository
    {
        /// <summary>
        /// Método responsável por listar todos os Paciente
        /// </summary>
        /// <returns>Uma lista de Pacientes</returns>
        List<Paciente> ListarTodos();

        /// <summary>
        /// Método responsável por buscar um Paciente pelo seu Id
        /// </summary>
        /// <param name="Id">Id do Paciente buscado</param>
        /// <returns>O Paciente com o Id buscado</returns>
        Paciente BuscarPoId(int Id);

        /// <summary>
        /// Método responsável por atualizar um Paciente pelo seu Id
        /// </summary>
        /// <param name="Id">Id do Paciente atualizado</param>
        /// <param name="PacienteAtualizado">Novos valores para a atualização</param>
        void Atualizar(int Id, Paciente PacienteAtualizado);

        /// <summary>
        /// Método Responsável por cadastrar um novo Paciente
        /// </summary>
        /// <param name="PacienteNovo">Novo Paciente a ser cadastrado</param>
        void Cadastrar(Paciente PacienteNovo);

        /// <summary>
        /// Método responsável por deletar um Paciente pelo seu Id
        /// </summary>
        /// <param name="Id">Id do Paciente deletado</param>
        void Deletar(int Id);
    }
}
