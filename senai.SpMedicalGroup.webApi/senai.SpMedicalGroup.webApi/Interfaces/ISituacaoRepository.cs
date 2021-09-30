using senai.SpMedicalGroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Interfaces
{
    public interface ISituacaoRepository
    {
        /// <summary>
        /// Método responsável por listar todas as Situacoes
        /// </summary>
        /// <returns>Uma lista de Situacoes</returns>
        List<Situacao> ListarTodos();

        /// <summary>
        /// Método responsável por buscar uma Situacao pelo seu Id
        /// </summary>
        /// <param name="Id">Id da Situacao buscada</param>
        /// <returns>A Situacao com o Id buscado</returns>
        Situacao BuscarPoId(int Id);

        /// <summary>
        /// Método responsável por atualizar uma Situacao pelo seu Id
        /// </summary>
        /// <param name="Id">Id da Situacao atualizada</param>
        /// <param name="SituacaoAtualizada">Novos valores para a atualização</param>
        void Atualizar(int Id, Situacao SituacaoAtualizada);

        /// <summary>
        /// Método Responsável por cadastrar uma nova Situacao
        /// </summary>
        /// <param name="SituacaoNova">Nova Situacao a ser cadastrada</param>
        void Cadastrar(Situacao SituacaoNova);

        /// <summary>
        /// Método responsável por deletar uma Situacao pelo seu Id
        /// </summary>
        /// <param name="Id">Id da Situacao deletada</param>
        void Deletar(int Id);
    }
}
