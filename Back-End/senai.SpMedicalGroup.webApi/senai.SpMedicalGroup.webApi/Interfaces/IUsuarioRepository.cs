using Microsoft.AspNetCore.Http;
using senai.SpMedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Interfaces
{
    interface IUsuarioRepository 
    {
        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="Email">E-mail do usuário</param>
        /// <param name="Senha">Senha do usuário</param>
        /// <returns>Um objeto do tipo Usuario que foi encontrado</returns>
        Usuario Login(string Email, string Senha);

        void SalvarPerfilDir(IFormFile Foto, int IdUsuario);

        string ConsultarPerfilDir(int IdUsuario);

        /// <summary>
        /// Método responsável por listar todos os Usuarios
        /// </summary>
        /// <returns>Uma lista de Usuarios</returns>
        List<Usuario> ListarTodos();

        /// <summary>
        /// Método responsável por buscar um Usuario pelo seu Id
        /// </summary>
        /// <param name="Id">Id do Usuario buscado</param>
        /// <returns>O Usuario com o Id buscado</returns>
        Usuario BuscarPoId(int Id);

        /// <summary>
        /// Método responsável por atualizar um Usuario pelo seu Id
        /// </summary>
        /// <param name="Id">Id do Usuario atualizado</param>
        /// <param name="UsuarioAtualizado">Novos valores para a atualização</param>
        void Atualizar(int Id, Usuario UsuarioAtualizado);

        /// <summary>
        /// Método Responsável por cadastrar um novo Usuario
        /// </summary>
        /// <param name="UsuarioNovo">Novo Usuario a ser cadastrado</param>
        void Cadastrar(Usuario UsuarioNovo);

        /// <summary>
        /// Método responsável por deletar um Usuario pelo seu Id
        /// </summary>
        /// <param name="Id">Id do Usuario deletado</param>
        void Deletar(int Id);
    }
}
