using senai.SpMedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Método responsável por listar todas os TiposUsuarios
        /// </summary>
        /// <returns>Uma lista de TiposUsuarios</returns>
        List<TipoUsuario> ListarTodos();

        /// <summary>
        /// Método responsável por buscar um TipoUsuario pelo seu Id
        /// </summary>
        /// <param name="Id">Id do TipoUsuario buscado</param>
        /// <returns>O TipoUsuario com o Id buscado</returns>
        TipoUsuario BuscarPoId(int Id);

        /// <summary>
        /// Método responsável por atualizar um TipoUsuario pelo seu Id
        /// </summary>
        /// <param name="Id">Id do TipoUsuario atualizado</param>
        /// <param name="TipoUsuarioAtualizado">Novos valores para a atualização</param>
        void Atualizar(int Id, TipoUsuario TipoUsuarioAtualizado);

        /// <summary>
        /// Método Responsável por cadastrar um novo TipoUsuario
        /// </summary>
        /// <param name="TipoUsuarioNovo">Novo TipoUsuario a ser cadastrado</param>
        void Cadastrar(TipoUsuario TipoUsuarioNovo);

        /// <summary>
        /// Método responsável por deletar um TipoUsuario pelo seu Id
        /// </summary>
        /// <param name="Id">Id do TipoUsuario deletado</param>
        void Deletar(int Id);
    }
}
