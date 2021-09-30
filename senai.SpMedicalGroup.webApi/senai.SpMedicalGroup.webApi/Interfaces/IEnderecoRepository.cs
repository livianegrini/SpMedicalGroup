using senai.SpMedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Interfaces
{
    interface IEnderecoRepository
    {
        /// <summary>
        /// Método responsável por listar todos os Enderecos
        /// </summary>
        /// <returns>Uma lista de Enderecos</returns>
        List<Endereco> ListarTodos();

        /// <summary>
        /// Método responsável por buscar um Endereco pelo seu Id
        /// </summary>
        /// <param name="Id">Id do Endereco buscado</param>
        /// <returns>O Endereco com o Id buscado</returns>
        Endereco BuscarPoId(int Id);

        /// <summary>
        /// Método responsável por atualizar um Endereco pelo seu Id
        /// </summary>
        /// <param name="Id">Id do Endereco atualizado</param>
        /// <param name="EnderecoAtualizado">Novos valores para a atualização</param>
        void Atualizar(int Id, Endereco EnderecoAtualizado);

        /// <summary>
        /// Método Responsável por cadastrar um novo Endereco
        /// </summary>
        /// <param name="EnderecoNovo">Novo Endereco a ser cadastrado</param>
        void Cadastrar(Endereco EnderecoNovo);

        /// <summary>
        /// Método responsável por deletar um Endereco pelo seu Id
        /// </summary>
        /// <param name="Id">Id do Endereco deletado</param>
        void Deletar(int Id);
    }
}
