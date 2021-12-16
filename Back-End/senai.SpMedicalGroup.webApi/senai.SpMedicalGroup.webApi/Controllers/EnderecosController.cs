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
    public class EnderecosController : ControllerBase
    {
        /// <summary>
        /// Objeto _EnderecoRepository que irá receber todos os métodos definidos na interface IEnderecoRepository
        /// </summary>
        private IEnderecoRepository _EnderecoRepository { get; set; }


        /// <summary>
        /// Instancia o objeto _EnderecoRepository para que haja referência às implementações feitas no repositório EnderecoRepository
        /// </summary>
        public EnderecosController()
        {
            _EnderecoRepository = new EnderecoRepository();
        }

        /// <summary>
        /// Lista todas os Endereco
        /// </summary>
        /// <returns>Uma lita de Enderecos com o status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_EnderecoRepository.ListarTodos());
        }

        /// <summary>
        /// Busca um Endereco pelo seu Id
        /// </summary>
        /// <param name="Id">Id do Endereco que será buscado</param>
        /// <returns>Um Endereco encontrado com o status code 200 - Ok</returns>
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            Endereco EnderecoBuscado = _EnderecoRepository.BuscarPoId(Id);

            if (EnderecoBuscado == null)
            {
                return NotFound("Nenhum Endereco encontrado!");
            }
            return Ok(EnderecoBuscado);
        }

        /// <summary>
        /// Atualiza um Endereco existente
        /// </summary>
        /// <param name="Id">Id de um Endereco que será atualizado</param>
        /// <param name="EnderecoAtualizado">>Objeto EnderecoAtualizado com as novas informações</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, Endereco EnderecoAtualizado)
        {
            try
            {
                Endereco EnderecoBuscado = _EnderecoRepository.BuscarPoId(Id);

                if (EnderecoBuscado != null)
                {
                    if (EnderecoAtualizado != null)
                       _EnderecoRepository.Atualizar(Id, EnderecoAtualizado);
                }
                else
                {
                    return BadRequest(new { mensagem = "Endereco informado não encontrado" });
                }

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um Endereco
        /// </summary>
        /// <param name="EnderecoNovo">>Objeto EnderecoNovo com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Cadastrar(Endereco EnderecoNovo)
        {
            _EnderecoRepository.Cadastrar(EnderecoNovo);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um Endereco existente
        /// </summary>
        /// <param name="Id">Id de Endereco que será deletado</param>
        /// <returns>Um status code 200 - Ok</returns>
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            _EnderecoRepository.Deletar(Id);
            return Ok();
        }
    }
}
