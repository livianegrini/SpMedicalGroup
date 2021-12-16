using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.SpMedicalGroup.webApi.Domains;
using senai.SpMedicalGroup.webApi.Interfaces;
using senai.SpMedicalGroup.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedicalGroup.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SituacoesController : ControllerBase
    {
        /// <summary>
        /// Objeto _SituacaoRepository que irá receber todos os métodos definidos na interface ISituacaoRepository
        /// </summary>
        private ISituacaoRepository _SituacaoRepository { get; set; }


        /// <summary>
        /// Instancia o objeto _SituacaoRepository para que haja referência às implementações feitas no repositório SituacaoRepository
        /// </summary>
        public SituacoesController()
        {
            _SituacaoRepository = new SituacaoRepository();
        }

        /// <summary>
        /// Lista todas as Situacoes
        /// </summary>
        /// <returns>Uma lita de Situacoes com o status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_SituacaoRepository.ListarTodos());
        }

        /// <summary>
        /// Busca uma Situacao pelo seu Id
        /// </summary>
        /// <param name="Id">Id da Situacao que será buscada</param>
        /// <returns>Uma Situacao encontrada com o status code 200 - Ok</returns>
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            Situacao SituacaoBuscada = _SituacaoRepository.BuscarPoId(Id);

            if (SituacaoBuscada == null)
            {
                return NotFound("Nenhuma Situacao encontrada!");
            }
            return Ok(SituacaoBuscada);
        }

        /// <summary>
        /// Atualiza uma Situacao existente
        /// </summary>
        /// <param name="Id">Id da Situacao que será atualizada</param>
        /// <param name="SituacaoAtualizada">>Objeto SituacaoAtualizada com as novas informações</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, Situacao SituacaoAtualizada)
        {
            try
            {
                Situacao SituacaoBuscada = _SituacaoRepository.BuscarPoId(Id);

                if (SituacaoBuscada != null)
                {
                    if (SituacaoAtualizada != null)
                        _SituacaoRepository.Atualizar(Id, SituacaoAtualizada);
                }
                else
                {
                    return BadRequest(new { mensagem = "Situacao informada não encontrada" });
                }

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        /// <summary>
        /// Cadastra uma Situacao
        /// </summary>
        /// <param name="SituacaoNova">>Objeto SituacaoNova com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Cadastrar(Situacao SituacaoNova)
        {
            _SituacaoRepository.Cadastrar(SituacaoNova);


            return StatusCode(201);
        }

        /// <summary>
        /// Deleta uma Situacao existente
        /// </summary>
        /// <param name="Id">Id da Situacao que será deletada</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            _SituacaoRepository.Deletar(Id);
            return Ok();
        }
    }
}
